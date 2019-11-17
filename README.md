# Checkout-Challenge
Interview assignment .NET challenge 2.0 for checkout.com - Building a Payment Gateway 

### Project Structure

* Payment Gateway API https://checkoutchallengeapi.azurewebsites.net/index.html
* Mock Bank API https://checkoutmockbank.azurewebsites.net/
* Azure DB - checkoutchallenge.database.windows.net
* Application Metrics - https://checkoutchallengeapi.azurewebsites.net/metrics

### Test Data

Test data based on checkout documentation responses 

https://docs.checkout.com/docs/testing

#### Test Currencies

| Currency Code
| ------------- |
| ZAR
| USD
| GBP

#### Test Banks

| Bank Name
| ------------- |
| MockBank
| LocalTestBank

#### Test Cards

| Card Type | Card Number | CVV |   
| ------------- |:-------------:| :-------------:| 
| Visa | 4242 4242 4242 4242 | 100 |
| Visa | 4543 4740 0224 9996 | 956 |
| Mastercard | 5436 0310 3060 6378 | 257 |
| Mastercard | 2223 0000 1047 9399 | 299 |

#### Test Merchants 

| Merchant        | MerchantID         
| ------------- |:-------------:| 
| Test Merchant 1 | A9B05E16-ACD8-4ACF-8E29-951E0D39DA9A |
| Test Merchant 2 | B3E7C684-99A2-4253-898B-01515B92F1B1 |
| Test Merchant 3 | E7039E52-410B-4A4A-8516-B15D64880734 |

#### Responses

To test the mock bank API responses, create a transaction with the amount listed below to replicate the required response.

| Amount        | Response         
| ------------- |:-------------:| 
| 200 | Successfull |
| 05 | Declined - Do not honour |
| 12 | Invalid payment |
| 14 | Invalid card number |
| 51 | Insufficient funds |
| 54 | Bad track data |
| 62 | Restricted card |
| 63 | Security violation |
| 9998 | Response received too late / timeout |
| 150 | Card not 3D Secure enabled |
| 6900 | Unable to specify if card is 3D Secure enabled |
| 5000 | 3D Secure system malfunction |
| 6510 | 3D Secure Authentication Required |
| 33 | Expired card - Pick up |
| 4001 | Payment blocked due to risk |
| 4008 | Gateway reject - Card number blacklisted |
| 2011 | Issuer initiated a stop payment (revocation order) for this authorization |
| 2013 | Issuer initiated a stop payment (revocation order) for all payment |
