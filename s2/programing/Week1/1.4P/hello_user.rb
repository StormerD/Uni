# linked library
require 'date'

# global constant
INCHES = 39.3701

# asks user for info about themselves then prints it to term
def main()
	# asks first name
	puts('What is your name?')
	name = gets()
	puts('Your name is ' + name + '!')
	# asks last name
	puts('What is your family name?')
	family_name = gets.chomp()
	puts('Your family name is: ' + family_name + '!')
	# asks born year
	puts('What year were you born?')
	year_born = gets.chomp()
	# Calculate the users age
	age = Date.today.year - year_born.to_i()
	puts('So you are ' + age.to_s + ' years old')
	# asks height (m)
	puts('Enter your height in metres (i.e as a float): ')
	value = gets.to_f()
	# converts height (m) to height (in)
	value = value * INCHES
	puts('Your height in inches is: ')
	puts(value.to_s())
	puts('Finished')
end

# initializes program
main()
