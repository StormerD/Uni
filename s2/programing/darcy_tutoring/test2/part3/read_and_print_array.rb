# reads in integers from the terminal and returns an array containing the integers
def read_array()
    print("How many integers are you entering? ")
    count = gets.chomp.to_i()
    i = 0
    ints = []

    while i < count
        print("Enter integer: ")
        int = gets.chomp.to_i()
        ints << int
        i += 1
    end
    return ints
end

# prints out a numbered list of items in the array
def print_array(ints)
    puts("Printing integers:")
    i = 0

    while i < ints.length()
        int = ints[i]
        puts(int.to_s())
        i += 1
    end
end 

def main()
    ints = read_array()
    print_array(ints)
end

main()