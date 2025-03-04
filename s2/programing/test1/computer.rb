# linked file "input_functions"
require './input_functions'

# INPUT FUNCTIONS FILE FUNCTIONS
#   read_string(prompt)
#   read_float(prompt)
#   read_integer(prompt)
#   read_integer_in_range(prompt, min (int), max (int))
#   read_boolean(prompt)

# Computer class
class Computer
    attr_accessor :id, :manufacturer, :model, :price
    
    def initialize (id, manufacturer, model, price)
        @id = id #(integer)
        @manufacturer = manufacturer #(string)
        @model = model #(string)
        @price = price #(float)
    end
end

# asks user for information about a computer
def read_a_computer()
	id = read_integer('Enter computer id:')
	manufacturer = read_string('Enter manufacturer:')
	model = read_string('Enter model:')
	price = read_float('Enter price:')

    # define new Computer class -> computer
    computer = Computer.new(id, manufacturer, model, price)
    # return computer class
    return computer
end

# gathers an array of user input values and returns it to "main()"
def read_computers()
    computers = Array.new()
    count = read_integer('How many computers are you entering:')
    i = 0
    while i < count
        computer = read_a_computer()
        computers << computer
        i += 1
    end
    # returns computers array
    return computers
end

# prints the information of a computer
def print_a_computer(a_computer)
	puts 'Id: ' + a_computer.id.to_s()
	puts 'Manufacturer: ' + a_computer.manufacturer
	puts 'Model: ' + a_computer.model
	printf("Price: %.2f\n", a_computer.price)
end

# loops the "print_a_computer()" function to print information on all the computers
def print_computers(computers)
    i = 0
    while i < computers.length()
        a_computer = computers[i]
        print_a_computer(a_computer)
        i += 1
    end
end

# gets array from "read_computers()" and prints the array usingn "print_computers()"
def main()
	computers = read_computers()
	print_computers(computers)
end

<<<<<<< HEAD
main() if __FILE__ == $0 
=======
# initializes main if the linked file exists
main() if __FILE__ == $0
>>>>>>> 26caf1acb8975ffae988f05879f06ae8b3e5f211
