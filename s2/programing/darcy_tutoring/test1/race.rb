require './input_functions'

# INPUT FUNCTIONS FILE FUNCTIONS
#   read_string(prompt)
#   read_float(prompt)
#   read_integer(prompt)
#   read_integer_in_range(prompt, min (int), max (int))
#   read_boolean(prompt)

# Race Class
class Race
    attr_accessor :description, :id, :start_time, :start_location

    def initialize (description, id, start_time, start_location)
        @description = description
        @id = id
        @start_time = start_time
        @start_location = start_location
    end
end

# records a single race
def read_a_race()
    # enter description
    description = read_string("Enter race description: ")
    # enter id
    id = read_string("Enter id: ")
    # enter start time
    start_time = read_string("Enter time: ")
    # enter start location
    start_location = read_string("Enter location: ")

    # spacer
    puts "- - - - - - - - - - - -"

    # create new race record
    race = Race.new(description, id, start_time, start_location)
    # return new record
    return race
end

# records multiple races
def read_races()
    count = read_integer("How many races are you entering: ")

    # spacer
    puts "- - - - - - - - - - - -"

    # while loop
    races = []
    i = 0
    while i < count.to_i()
        race = read_a_race()
        races << race
        i += 1
    end
    return races
end

# prints a single race
def print_a_race(race)
    puts("Race description " + race.description)
    puts("Id " + race.id)
    puts("Time " + race.start_time)
    puts("Location " + race.start_location)

    # spacer
    puts "- - - - - - - - - - - -"
end

# print multiple races
def print_races(races)
    # while loop
    i = 0
    while i < races.length()
        race = races[i]
        print_a_race(race)
        i += 1
    end
end

def main() 
    races = read_races()
    print_races(races)
end

main() if __FILE__ == $0