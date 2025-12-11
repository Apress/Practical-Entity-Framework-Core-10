param (
    [string]$server = "localhost",
    [string]$database = "AdventureWorksEF10",
    [string]$username = "sa",
    [string]$password = "Password#123!",
    [string]$outputPath = "./safe-scaffold-command.txt"
)

#NOTE: Change the connection string to use native windows auth if that is what you are using (ignore username/password):
# Data Source=$server;Initial Catalog=$database;Trusted_Connection=True";TrustServerCertificate=True;MultipleActiveResultSets=False;
#
$connectionString = "Server=$server;Database=$database;User ID=$username;Password=$password;TrustServerCertificate=True;MultipleActiveResultSets=False"

function Get-DataTable {
    param ([string]$query)
    $dt = New-Object System.Data.DataTable
    try {
        $conn = New-Object System.Data.SqlClient.SqlConnection $connectionString
        $cmd = $conn.CreateCommand()
        $cmd.CommandText = $query
        $conn.Open()
        $dt.Load($cmd.ExecuteReader())
        $conn.Close()
    } catch {
        Write-Host "❌ $($_.Exception.Message)" -ForegroundColor Red
    }
    return $dt
}

Write-Host "🔍 Identifying unsupported tables..." -ForegroundColor Cyan
$badTablesQuery = @"
SELECT DISTINCT s.name AS SchemaName, t.name AS TableName
FROM sys.columns c
JOIN sys.tables t ON t.object_id = c.object_id
JOIN sys.schemas s ON s.schema_id = t.schema_id
JOIN sys.types ty ON ty.user_type_id = c.user_type_id
WHERE ty.name IN ('hierarchyid', 'geography', 'geometry')
UNION
SELECT DISTINCT s.name, t.name
FROM sys.indexes i
JOIN sys.index_columns ic ON i.object_id = ic.object_id AND i.index_id = ic.index_id
JOIN sys.columns c ON c.object_id = ic.object_id AND c.column_id = ic.column_id
JOIN sys.tables t ON t.object_id = i.object_id
JOIN sys.schemas s ON s.schema_id = t.schema_id
JOIN sys.types ty ON ty.user_type_id = c.user_type_id
WHERE i.is_primary_key = 1 AND ty.name IN ('hierarchyid', 'geography', 'geometry')
ORDER BY 1, 2
"@
$badTables = Get-DataTable $badTablesQuery
$badList = @()
if ($badTables.Rows.Count -gt 0) {
    Write-Host "❌ Problem tables found:" -ForegroundColor Red
    $badTables | Format-Table -AutoSize
    $badTables | ForEach-Object { $badList += "$($_.SchemaName).$($_.TableName)" }
}

Write-Host "`n✅ Building safe table list..." -ForegroundColor Cyan
$allTablesQuery = @"
SELECT s.name AS SchemaName, t.name AS TableName
FROM sys.tables t
JOIN sys.schemas s ON s.schema_id = t.schema_id
WHERE t.is_ms_shipped = 0
ORDER BY s.name, t.name
"@
$allTables = Get-DataTable $allTablesQuery
$safeTables = $allTables | Where-Object {
    $fqtn = "$($_.SchemaName).$($_.TableName)"
    -not ($badList -contains $fqtn)
}
$safeList = $safeTables | ForEach-Object { "$($_.SchemaName).$($_.TableName)" }

Write-Host "`n✅ Writing safe EF scaffold command..." -ForegroundColor Green
$tablesArg = $safeList -join ' '
$cmd = "dotnet ef dbcontext scaffold `"Name=AWDbConnection`" Microsoft.EntityFrameworkCore.SqlServer --project EF10_AWDBLibrary --startup-project EF10_Activity0201 --output-dir Models --context AdventureWorksContext --force --tables $tablesArg"
Set-Content -Path $outputPath -Value $cmd
Write-Host "`n📄 EF scaffold command saved to $outputPath" -ForegroundColor Yellow