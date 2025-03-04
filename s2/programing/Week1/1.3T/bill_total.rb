# user inputs prices for meal types
def main()
	# ask user for appetizer price
	puts('Enter the appetizer price:')
	appetizer_price = gets.chomp.to_f()

	# ask user for main price
	puts('Enter the main price:')
	main_price = gets.chomp.to_f()

	# ask user for dessert price
	puts('Enter the dessert price:')
	dessert_price = gets.chomp.to_f()

	# add up the price for the appetizer, main and dessert
	total_price = appetizer_price + main_price + dessert_price

	# prints the total price
	print("$")
	printf("%.2f", total_price) # format the float to 2 decimal places
	print("\n") # print a newline character to move down one line
end

# initializes program
main()