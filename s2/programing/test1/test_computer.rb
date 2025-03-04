require './inputfunctions'

Complete the code below
Use input_functions to read the data from the user
define a Computer below:
class Computer
    attr_accessor :id, :manu, :model, :price

    def initialize (id, manu, model, price)
        @id = id
        @manu = manu
        @model = model
        @price = price
    end
end


def read_a_computer()
    # put more code here
    id = read_integer('Enter computer id:')
    manu = read_string('Enter manufacturer:')
    model = read_string('Enter model:')
    price = read_float('Enter price:')

    computer = Computer.new(id, manu, model, price)
    return computer
end

def read_computers()
    computers = Array.new()
    amount = read_integer('How many computers are you entering:')
    x = 0
    while x < amount
        computer = read_a_computer()
        computers << computer
        x += 1
    end
    return computers
end

def print_a_computer(a_computer)
    puts 'Computer id: ' + a_computer.id.to_s()
    puts 'Manufacturer: ' + a_computer.manu
    puts 'Model: ' + a_computer.model
    printf("Price: %.2f\n", a_computer.price)

end

def print_computers(computers)
    len = computers.length()
    i = 0
    while i < len
        a_computer = computers[i]
        print_a_computer(a_computer)
        i += 1
    end
end
  # use the following line to print the price with just 2 decimal places. See Task 1.3

def main()
    computers = read_computers()
    print_computers(computers)
end

main() if __FILE__ == $0