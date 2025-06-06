
# Display the prompt and return the read string
def read_string prompt
	puts prompt
	value = gets.chomp
	return value
end

# Display the prompt and return the read float
def read_float prompt
	value = read_string(prompt)
	return value.to_f
end

# Display the prompt and return the read integer
def read_integer prompt
	value = read_string(prompt)
	return value.to_i
end

# Read an integer between min and max, prompting with the string provided

def read_integer_in_range(prompt, min, max)
	value = read_integer(prompt)
	while (value < min or value > max)
		puts "Please enter a value between " + min.to_s + " and " + max.to_s + ": "
		value = read_integer(prompt);
	end
	return value
end

# Display the prompt and return the read Boolean

def read_boolean prompt
	value = read_string(prompt)
	case value
	when 'y', 'yes', 'Yes', 'YES'
		return true
	else
		return false
	end
end

# Test the functions above


def main 
	puts "String entered is: " + read_string("Enter a String: ")
	puts "Boolean is: " + read_boolean("Enter yes or no:").to_s
	puts "Float is: " + read_float("Enter a floating point number: ").to_s
	puts "Integer is: " + read_integer_in_range("Enter an integer between 3 and 6: ", 3, 6).to_s
end

main if __FILE__ == $0

