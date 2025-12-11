# Listing 7-4: Ensure that all *.sql files are embedded

In order to use the scripting strategy, all of the referenced files need to be embedded.  

## The XML for the project file.

It is far too easy to forget to add files as `embedded` when creating them.  Additionally, embedding each file would quickly make for a very large XML block in the project file.  For that reason, embedding by wildcard match is a solid solution.

## The XML

The XML the follows can be found in the `EF10_InventoryDBLibrary` project.

```XML
<ItemGroup>
  <Folder Include="Features\StoredProceduresViewsFunctions\Listings\" />
</ItemGroup>
```  