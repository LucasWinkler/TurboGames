Routes:

Index		->	/Cart
Checkout	->	/Cart/Checkout
Success		->	/Cart/Checkout/Success

Pages:
	- Index
		- Display all items in cart and provide the ability to remove an item.
		- Show the order total.
		- 'Proceed to checkout' button -> ./Checkout

	- Checkout
		- Potential bootstrap template: https://orbitthemes.com/themes/checkout-plus/
		- Displays all items in cart (readonly)
		- Shows the order total.
		- Billing address
			- 2 radio buttons
				1. Choose existing address (default if exists)
				2. Enter new address (default if no existing addresses)

		- Shipping address
			- 2 radio buttons
				1. Choose existing address (default if exists)
				2. Enter new address (default if no existing addresses)
			- Checkbox to use billing as shipping.

		- Payment (Payment model needs to be reworked similar to addresses before this can be completed)
			- 2 radio buttons
				1. Choose existing card (default if exists)
				2. Enter new card (default if no existing card)
			- 'Purchase' button -> ./Success
		
	- Success
		- Says that the order was successful
		- Display
			- Order items
			- Billing & shipping addresses
			- Last 4 digits of payment card
		- 'Continue shopping' button
		- 'View to your games' button