# linked file
require_relative 'input_functions'

# formats a letter from user inputs
def main()
    # title
    title = read_string("Please enter your title: (Mr, Mrs, Ms, Miss, Dr)")
    # first name
    fname = read_string("Please enter your first name:")
    # last name
    lname = read_string("Please enter your last name:")
    # house number
    house = read_string("Please enter the house or unit number:")
    # street name
    street = read_string("Please enter the street name:")
    # suburb
    suburb = read_string("Please enter the suburb:")
    # postcode
    postcode = read_integer_in_range("Please enter a postcode (0000 - 9999)", "0", "9999")
    # letter subject
    subject = read_string("Please enter your message subject line:")
    # letter message
    message = read_string("Please enter your message content:")

    # prints letter with variables
    puts(title + " " + fname + " " + lname + "\n")
    puts(house + " " + street + "\n")
    puts(suburb + " " + postcode + "\n")
    puts("RE: " + subject + "\n")
    puts()
    puts(message + "\n")
end

# initializes main if the linked file exists
main() if __FILE__ == $0