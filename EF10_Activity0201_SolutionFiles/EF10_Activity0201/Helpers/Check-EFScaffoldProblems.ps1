param (
    [string]$server = "localhost",
    [string]$database = "AdventureWorksEF10",
    [string]$username = "sa",
    [string]$password = "your-password-here"
)
#NOTE: Change the connection string to use native windows auth if that is what you are using (ignore username/password):
# Data Source=$server;Initial Catalog=$database;Trusted_Connection=True";TrustServerCertificate=True;MultipleActiveResultSets=False;
#

$connectionString = "Server=$server;Database=$database;User ID=$username;Password=$password;TrustServerCertificate=True;MultipleActiveResultSets=False"

function Test-Connection {
    try {
        $conn = New-Object System.Data.SqlClient.SqlConnection $connectionString
        $conn.Open()
        $conn.Close()
        return $true
    }
    catch {
        Write-Host "❌ Connection failed: $($_.Exception.Message)" -ForegroundColor Red
        return $false
    }
}

function Get-DataTable {
    param (
        [string]$query
    )
    $dt = New-Object System.Data.DataTable
    try {
        $conn = New-Object System.Data.SqlClient.SqlConnection $connectionString
        $cmd = $conn.CreateCommand()
        $cmd.CommandText = $query
        $conn.Open()
        $dt.Load($cmd.ExecuteReader())
        $conn.Close()
    }
    catch {
        Write-Host "❌ Query failed: $($_.Exception.Message)" -ForegroundColor Red
    }
    return $dt
}

Write-Host "🔑 Testing SQL Server connection as '$username' to '$database' on '$server'..." -ForegroundColor Yellow

if (-not (Test-Connection)) {
    Write-Host "⚠️ Aborting scan. Check your credentials or database settings." -ForegroundColor Red
    return
}

Write-Host "✅ Connection successful.`n" -ForegroundColor Green

Write-Host "🔍 Scanning for unsupported data types..." -ForegroundColor Cyan
$badTypesQuery = @"
SELECT TABLE_SCHEMA, TABLE_NAME, COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE DATA_TYPE IN ('hierarchyid', 'geography', 'geometry')
ORDER BY TABLE_SCHEMA, TABLE_NAME
"@
$badTypes = Get-DataTable $badTypesQuery
if ($badTypes.Rows.Count -gt 0) {
    Write-Host "`n❌ Unsupported column types found:" -ForegroundColor Red
    $badTypes | Format-Table -AutoSize
} else {
    Write-Host "✅ No unsupported types found." -ForegroundColor Green
}

Write-Host "`n🔍 Scanning for tables with NO primary key..." -ForegroundColor Cyan
$noPKQuery = @"
SELECT s.name AS SchemaName, t.name AS TableName
FROM sys.tables t
JOIN sys.schemas s ON s.schema_id = t.schema_id
WHERE NOT EXISTS (
    SELECT 1 FROM sys.indexes i
    WHERE i.object_id = t.object_id AND i.is_primary_key = 1
)
ORDER BY s.name, t.name
"@
$noPKTables = Get-DataTable $noPKQuery
if ($noPKTables.Rows.Count -gt 0) {
    Write-Host "`n⚠️ Tables without primary keys:" -ForegroundColor Yellow
    $noPKTables | Format-Table -AutoSize
} else {
    Write-Host "✅ All tables have primary keys." -ForegroundColor Green
}

Write-Host "`n🔍 Scanning for PKs involving unsupported types..." -ForegroundColor Cyan
$badPKQuery = @"
SELECT s.name AS SchemaName, t.name AS TableName, c.name AS ColumnName, ty.name AS DataType
FROM sys.indexes i
JOIN sys.index_columns ic ON i.object_id = ic.object_id AND i.index_id = ic.index_id
JOIN sys.columns c ON c.object_id = ic.object_id AND c.column_id = ic.column_id
JOIN sys.tables t ON t.object_id = i.object_id
JOIN sys.schemas s ON s.schema_id = t.schema_id
JOIN sys.types ty ON ty.user_type_id = c.user_type_id
WHERE i.is_primary_key = 1 AND ty.name IN ('hierarchyid', 'geography', 'geometry')
ORDER BY s.name, t.name
"@
$badPKs = Get-DataTable $badPKQuery
if ($badPKs.Rows.Count -gt 0) {
    Write-Host "`n❌ Primary keys involving unsupported types:" -ForegroundColor Red
    $badPKs | Format-Table -AutoSize
} else {
    Write-Host "✅ No PKs use unsupported types." -ForegroundColor Green
}

Write-Host "`n✅ Scan complete." -ForegroundColor Cyan
