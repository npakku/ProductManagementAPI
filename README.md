# ProductManagementAPI Documenataion

#Base URL
-------------------------------------------------------------------------------------
https://productmgapi-h7hkdpfeedd7a4b3.canadacentral-01.azurewebsites.net/api/product

# API Endpoints
-------------------------------------------------------------------------------------
## 1. Get All Products
## 2. Get Product By Id
## 3. Create Product
## 4. Update Product
## 5. Delete Product
----------------------------------------------------------------------------------------------


# 1. Get All Products
## Endpoint GET: /product

## Example Request in Postman
## 1. Set the Method to GET
## 2. Enter the url: https://productmgapi-h7hkdpfeedd7a4b3.canadacentral-01.azurewebsites.net/api/product
## 3. Send the request and analyze response

# EXAMPLE RESPONSE
[
  {
    "id": 1,
    "name": "Laptop"
  },
  {
    "id": 2,
    "name": "Phone"
  },
  {
    "id": 3,
    "name": "Car"
  },
  {
    "id": 4,
    "name": "Sample Product"
  }
]
--------------------------------------------------------------------------------------------------------------------
# 2 Get Product 
##Endpont GET: product/Id

# Example Request in Postman
##1. Set the Method to GET
##2. Enter the url : https://productmgapi-h7hkdpfeedd7a4b3.canadacentral-01.azurewebsites.net/api/product/3
##3. Send request and analyze response

## EXAMPLE RESPONSE 
   { "name": "Car"}
------------------------------------------------------------------------------------------------------------------------

# 4 Create A Product
##Endpoint POST: product/
##Headers
##Key      ----	    Value
Content-Type	---- application/json
#Body(raw, json)
{
  "Name" : "Test Two"
}
# Sample Postman Request
## 1. Set the Method to POST
## 2. Enter the url : https://productmgapi-h7hkdpfeedd7a4b3.canadacentral-01.azurewebsites.net/api/product
## 3. Send request and analyzer response
## SAMPLE RESPONSE
Successfully Created!
-------------------------------------------------------------------------------------------------------------------------
# 5. Update Product
##Endpoint PUT: product/{productId}
##Key	                   Value
Content-Type	---- application/json
#Body(raw, json)
{
  "Id" : 6
  "Name" : "Test Three"
}
# Sample Postman Request
## 1. Set the Method to PUT
## 2. Enter the url : https://productmgapi-h7hkdpfeedd7a4b3.canadacentral-01.azurewebsites.net/api/product
## 3. Send request and analyzer response
## SAMPLE RESPONSE

# 5. Delete Product
# Enpoint DELETE:  /product/{productId}
## 1. Set the Method to DELETE
## 2. Enter the url : https://productmgapi-h7hkdpfeedd7a4b3.canadacentral-01.azurewebsites.net/api/product/4
## 3. Send request and analyzer response
## SAMPLE RESPONSE
NoContent











