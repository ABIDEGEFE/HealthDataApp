

resourceGroup="appRG"
SQL_Server="healthServerDB"
SQL_DB="healthDB"
location="central canada"

# create resource group

az group create \
   --name $resourceGroup \
   --location "$location"

# create sql server

az sql server create \
  --name $SQL_Server \
  --resource-group $resourceGroup \
  --location "$location" \
  --admin-user "Abinet" \
  --admin-password "ABne665506**"

# create firewall rule to allow resource to access the database

az sql server firewall-rule create \
   --resource-group $resourceGroup \
   --server $SQL_Server \
   --name FWRuleAllowAzure \
   --start-ip-address 0.0.0.0 \
   --end-ip-address 0.0.0.0

# create a database under the server

az sql db create \
   --resource-group $resourceGroup \
   --server $SQL_Server \
   --name $SQL_DB \
   --service-objective S0

