# Checkout-Challenge
Interview assignment .NET challenge 2.0 for checkout.com - Building a Payment Gateway 

### Project Structure

* Payment Gateway API https://checkoutchallengeapi.azurewebsites.net/index.html
* Mock Bank API https://checkoutmockbank.azurewebsites.net/
* Azure DB - checkoutchallenge.database.windows.net

### Test Data

Test data based on checkout documentation responses 

https://docs.checkout.com/docs/testing

#### Test Merchants 


| Merchant        | MerchantID         
| ------------- |:-------------:| 
| Test Merchant 1 | 1D620903-D485-4421-958F-8265C0B41844 |
| Test Merchant 2 | 311BFB23-11F9-44DA-B3F9-EF53DA3E6753 |
| Test Merchant 3 | 5D161A26-91A4-4784-8DEF-FAF0A3F9E8B7 |


#### Responses

To test the mock bank API responses, create a transaction with the amount listed below to replicate the required response.

| Amount        | Response         
| ------------- |:-------------:| 
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

