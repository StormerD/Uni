# Programming Test 2 Part 4

# define Polarising module
module Polarising
    Anisotropic, Isotropic, Unknown = *1..2
end

# define Polarising_names array
Polarising_names = ["Null", "Anisotropic", "Isotropic", "Unknown"]

# Gemstone class
class Gemstone
    attr_accessor :name, :polarising, :hardness
    # dont initialize attributes
end