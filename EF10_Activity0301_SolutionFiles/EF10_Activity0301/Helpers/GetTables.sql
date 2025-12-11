SELECT 
    QUOTENAME(s.name) + '.' + QUOTENAME(t.name) AS TableName
FROM 
    sys.tables t
JOIN 
    sys.schemas s ON t.schema_id = s.schema_id
WHERE 
    t.is_ms_shipped = 0
    AND NOT EXISTS (
        -- skip tables with unsupported column types
        SELECT 1
        FROM sys.columns c
        JOIN sys.types ty ON c.user_type_id = ty.user_type_id
        WHERE c.object_id = t.object_id
          AND ty.name IN ('hierarchyid', 'geography', 'geometry')
    )
    AND EXISTS (
        -- include only tables that have a primary key
        SELECT 1
        FROM sys.indexes i
        WHERE i.object_id = t.object_id AND i.is_primary_key = 1
    )
ORDER BY 
    s.name, t.name;
