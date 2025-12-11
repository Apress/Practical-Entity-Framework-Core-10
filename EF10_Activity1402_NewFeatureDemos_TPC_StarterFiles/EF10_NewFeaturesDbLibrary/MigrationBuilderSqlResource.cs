using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EF10_NewFeaturesDbLibrary;

public static class MigrationBuilderSqlResource
{
    public static OperationBuilder<SqlOperation> SqlResource(this MigrationBuilder mb, string relativeFileName)
    {
        var assembly = Assembly.GetAssembly(typeof(MigrationBuilderSqlResource));

        using (var stream = assembly?.GetManifestResourceStream(relativeFileName) ?? throw new FileNotFoundException("Embedded SQL Resource missing"))
        {
            using (var ms = new MemoryStream())
            {
                //get the stream to memory
                stream.CopyTo(ms);

                //Decode without BOM
                var text = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false)
                                .GetString(ms.ToArray());

                //read the file and return the code to execute
                return mb.Sql(text);
            }
        }
    }
}
