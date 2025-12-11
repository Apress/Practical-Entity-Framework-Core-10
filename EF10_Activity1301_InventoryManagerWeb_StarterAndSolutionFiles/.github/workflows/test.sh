# Variables
RG_NAME="rg-inventorymanager"
APP_NAME="app-invmgr-20251231blg"
SLOT="staging"

echo "Checking connection strings..."
az webapp config connection-string list \
  --name $APP_NAME \
  --resource-group $RG_NAME \
  --slot $SLOT

echo -e "\nGetting outbound IP addresses..."
az webapp show \
  --name $APP_NAME \
  --resource-group $RG_NAME \
  --query outboundIpAddresses

echo -e "\nFetching App Settings..."
az webapp config appsettings list \
  --name $APP_NAME \
  --resource-group $RG_NAME \
  --slot $SLOT

echo -e "\nCheck Azure SQL Server firewall settings (manual step):"
echo "Go to your Azure SQL Server > Networking"
echo "Ensure 'Allow Azure Services' is enabled"
echo "Add each IP address listed above to the SQL Server firewall if not already added"
