<<<<<<< HEAD
<<<<<<< HEAD
# My Functions - - - - - - -




# Display the prompt and return the read string
def read_string prompt
	puts prompt
	value = gets.chomp
	return value.to_s
end

# Display the prompt and return the read float
def read_float prompt
	value = read_string(prompt)
	value.chomp.to_f
	return value.to_s
end

# Display the prompt and return the read integer
def read_integer prompt
	value = read_string(prompt)
	value.to_i()
	return value
end

# Read an integer between min and max, prompting with the string provided

=======
# display the prompt and return the read string
def read_string prompt
	puts prompt
	value = gets.chomp
	return value
end

# display the prompt and return the read float
def read_float prompt
	value = read_string(prompt)
	return value.to_f
end

# display the prompt and return the read integer
def read_integer prompt
	value = read_string(prompt)
	return value.to_i
end

# read an integer between min and max, prompting with the string provided
>>>>>>> d531d7181f54d90bc8a7db5b793c3c222db364a0
def read_integer_in_range(prompt, min, max)
	value = read_integer(prompt)
	while (value < min or value > max)
		puts "Please enter a value between " + min.to_s + " and " + max.to_s + ": "
		value = read_integer(prompt);
	end
	return value
end

<<<<<<< HEAD
# Display the prompt and return the read Boolean

def read_boolean prompt
	value = read_string(prompt)
	case value
	when 'y', 'Y', 'yes', 'Yes', 'YES'
=======
# display the prompt and return the read Boolean
def read_boolean prompt
	value = read_string(prompt)
	case value
	when 'y', 'yes', 'Yes', 'YES'
>>>>>>> d531d7181f54d90bc8a7db5b793c3c222db364a0
		return true
	else
		return false
	end
<<<<<<< HEAD
end

def print_float(value, decimal_places)
	print(value.round(decimal_places).to_s.chomp('.0'))
end

# Test the functions above

def main 
	puts "String entered is: " + read_string("Enter a String: ")
	puts "Boolean is: " + read_boolean("Enter yes or no:").to_s
	puts "Float is: " + read_float("Enter a floating point number: ").to_s
	puts "Integer is: " + read_integer_in_range("Enter an integer between 3 and 6: ", 3, 6).to_s
end

main if __FILE__ == $0
=======
end
>>>>>>> d531d7181f54d90bc8a7db5b793c3c222db364a0
=======
>>>>>>> d18ab8ad64487ed6d94f738efcb159e49c2ebf79
