dotnet publish --os linux --arch x64 /t:PublishContainer api.cs

echo -e "\n\033[1;32m=========================================="
echo -e "       RUNNING WORKING APPHOST (13.0.0)      "
echo -e "==========================================\033[0m"

# Update apphost.cs to version 13.0.0
sed -i '1,2c\
#:package Aspire.Hosting.Azure.Storage@13.0.0\
#:sdk Aspire.AppHost.Sdk@13.0.0' apphost.cs

aspire run

echo -e "\n\033[1;31m=========================================="
echo -e "       RUNNING BROKEN APPHOST (13.1.0)       "
echo -e "==========================================\033[0m"

# Update apphost.cs to version 13.1.0
sed -i '1,2c\
#:package Aspire.Hosting.Azure.Storage@13.1.0\
#:sdk Aspire.AppHost.Sdk@13.1.0' apphost.cs

aspire run