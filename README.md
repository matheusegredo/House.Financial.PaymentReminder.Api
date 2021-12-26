# House.Financial.PaymentReminder.Api

House.Financial.PaymentReminder.Api is a personal project to add and handle payments who need to be reminded.

## Methods:

- Post
```bash
{
   "name": "string",
   "value": 0.00,
   "date": "2021-01-01"
}

# returns
{
    "data": [
        {
            "message": "Payment reminder inserted succesfully!",            
        },        
    ],
    "statusCode": 200,
    "errors": null
}
```

- Put
```bash
{
   "id": 1,
   "name": "string",
   "value": 0.00,
   "date": "2021-01-01"
}

# returns
{
    "data": [
        {
            "message": "Payment reminder updated succesfully!",            
        },        
    ],
    "statusCode": 200,
    "errors": null
}
```

- Get
```bash
{ }

# returns
{
    "data": [
       {
            "name": "string",
            "value": 0.00,
            "expireDate": "01/01/2021",
            "daysLeft": 1
        },        
    ],
    "statusCode": 200,
    "errors": null
}
```

- Get/{id}
```bash
not implemented.
```
