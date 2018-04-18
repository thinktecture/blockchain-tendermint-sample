openssl req -newkey rsa:2048 -nodes -keyout Telco1.private.pem -x509 -days 1000 -out Telco1.pem -subj "/C=DE/CN=Telco1/O=Thinktecture AG/L=Karlsruhe"
openssl pkcs12 -inkey Telco1.private.pem -in Telco1.pem -export -out Telco1.p12 -passout pass:thinktecture

openssl req -newkey rsa:2048 -nodes -keyout Telco2.private.pem -x509 -days 1000 -out Telco2.pem -subj "/C=DE/CN=Telco2/O=Thinktecture AG/L=Karlsruhe"
openssl pkcs12 -inkey Telco2.private.pem -in Telco2.pem -export -out Telco2.p12 -passout pass:thinktecture

openssl req -newkey rsa:2048 -nodes -keyout Telco3.private.pem -x509 -days 1000 -out Telco3.pem -subj "/C=DE/CN=Telco3/O=Thinktecture AG/L=Karlsruhe"
openssl pkcs12 -inkey Telco3.private.pem -in Telco3.pem -export -out Telco3.p12 -passout pass:thinktecture

openssl req -newkey rsa:2048 -nodes -keyout Regulator.private.pem -x509 -days 1000 -out Regulator.pem -subj "/C=DE/CN=Regulator/O=Thinktecture AG/L=Karlsruhe"
openssl pkcs12 -inkey Regulator.private.pem -in Regulator.pem -export -out Regulator.p12 -passout pass:thinktecture

cp -f ./Telco1.p12 ../NumberTransfer/NumberTransferWebApi/wwwroot/
cp -f ./Telco2.p12 ../NumberTransfer/NumberTransferWebApi/wwwroot/
cp -f ./Telco3.p12 ../NumberTransfer/NumberTransferWebApi/wwwroot/
cp -f ./Regulator.p12 ../NumberTransfer/NumberTransferWebApi/wwwroot/

rm -f publickeys.txt
sed '$d' Telco1.pem | sed '1d' | tr -d '\n' > publickeys.txt
echo "\n\n" >> publickeys.txt 
sed '$d' Telco2.pem | sed '1d' | tr -d '\n' >> publickeys.txt
echo "\n\n" >> publickeys.txt
sed '$d' Telco3.pem | sed '1d' | tr -d '\n' >> publickeys.txt
echo "\n\n" >> publickeys.txt
sed '$d' Regulator.pem | sed '1d' | tr -d '\n' >> publickeys.txt
echo "\n\n" >> publickeys.txt