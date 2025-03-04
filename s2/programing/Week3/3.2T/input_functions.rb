# display the prompt and return the read string
def read_string(prompt)
	puts(prompt)
	value = gets.chomp()
	return value
end

# display the prompt and return the read float
def read_float(prompt)
	value = read_string(prompt)
	value.to_f()
	return value
end

# display the prompt and return the read integer
def read_integer(prompt)
	value = read_string(prompt)
	value.to_i()
	return value
end

# read an integer between min and max, prompting with the string provided
def read_integer_in_range(prompt, min, max)
	value = read_integer(prompt)
	while (value < min.to_i or value > max.to_i)
		puts("Please enter a value between " + min.to_s + " and " + max.to_s + ": ")
		value = read_integer(prompt)
	end
	return value
end

# display the prompt and return the read Boolean
def read_boolean(prompt)
	value = read_string(prompt)
	case value
	when 'y', 'yes', 'Yes', 'YES'
		return true
	else
		return false
	end
end