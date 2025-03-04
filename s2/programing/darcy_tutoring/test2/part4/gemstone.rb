module Polarising
    Anisotropic, Isotropic, Unknown = *1..2
end

Polarising_names = ["Null", "Anisotropic", "Isotropic", "Unknown"]

class Gemstone
    attr_accessor :name, :polarising, :hardness
end