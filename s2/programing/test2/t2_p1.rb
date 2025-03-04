# Programming Test 2 Part 1

# prints different outputs based on age input
def main()
    # ask user for age
    print("Enter your age: ")
    age = gets.chomp.to_i()
    
    # output different strings based on age
    if age < 0 || age > 120
        # < 0 or > 120 - "Invalid age"
        puts("Invalid age")
    elsif age >= 0 && age <= 12
        # 0 - 12 (inclusive) - "You are a child"
        puts("You are a child")
    elsif age >= 13 && age <= 19
        # 13 - 19 (inclusive) - "You are a teenager"
        puts("You are a teenager")
    elsif age > 19 && age < 121
        # 20 - 120 - "You are an adult"
        puts("You are an adult")
    end
end

# initializes program
main()