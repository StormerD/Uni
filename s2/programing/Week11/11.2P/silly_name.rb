# prints silly for name
def print_silly_name(name)
    puts(name + " is a ")
    index = 0
    while index < 60
        print("silly ")
        index += 1
    end
    puts("name!")
end

# reads string
def read_string(prompt)
    puts(prompt)
    value = gets.chomp()
    return value
end

# main function
def main()

    name = read_string("What is your name? ")
    # checks if name is silly or not
    if name == "Kayla" || name == "kayla" || name == "Dylan" || name == "dylan"
        puts(name + " is an awesome name!")
    else
        print_silly_name(name)
    end
end

main()