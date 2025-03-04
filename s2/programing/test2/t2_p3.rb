# Programming Test 2 Part 3

# reads ints from term and returns array of ints
def read_array()
    # define new intArr as new array
    intArr = Array.new()
    # get number of ints from user
    print("How many integers are you entering? ")
    count = gets.chomp.to_i()
    i = 0
    # asks user to provide all the integers
    while i < count
        print("Enter integer: ")
        int = gets.chomp()
        intArr << int
        i += 1
    end
    # returns array of values
    return intArr
end

# a = integer array
# prints the out a numbered list of array items
def print_array(a)
    puts("Printing integers:")
    i = 0
    while i < a.length()
        puts(a[i].to_s())
        i += 1
    end
end
  
# calls read_array() then passes the returned array as an argument into a call to print_array(a)
def main()
    intArr = read_array()
    print_array(intArr)
end

# initializes program
main()