# Checkout Kata

A working checkout which periodically scans items and can return the total price of those items taking into account any special offers that apply to the scanned items.

## Items
| SKU | Unit Price |
|---|---|
| A99 | 0.50 |
| B15 | 0.30 |
| C40 | 0.45 |

## Special Offers
| SKU | Quantity | Offer Price |
|---|---|---|
| A99 | 3 | 1.30 |
| B15 | 2 | 0.45 |

## Further Work
A couple of ideas on potential future requirements
- Instead of having the *GetSpecialOffers()* method return a hard coded list of offers, this information should be stored in a database and all the data should be retrieved from there.
- The *GetSpecialOffers()* method could also be made public so special offers could be displayed on an interface.
- With an interface, there could be a new requirement to show the user that if they purchase one more of a single item they will qualify for a special offer.
- The *Scan()* method could be extended to take in a count parameter which would add a product to the scanned items list *n* times instead of calling *Scan() n* times.
- Alternatively, a new method called *ScanMultiple()* could be created to add multiple items to the basket at once.
