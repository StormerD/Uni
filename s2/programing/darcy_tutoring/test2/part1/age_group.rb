def main() 
    # get the age
    print("Enter your age: ")
    age = gets.chomp.to_i()

    # commence if statements
    if age < 0 || age > 120
        puts("Invalid age")
    elsif age >= 0 && age <= 12
        puts("You are a child")
    elsif age >= 13 && age <= 19
        puts("You are a teenager")
    elsif age > 19
        puts("You are an adult")
    end
end

main()