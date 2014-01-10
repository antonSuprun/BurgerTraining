class Car

  attr_reader :state
  
  def initialize engine, tires
    @engine = engine
    @tires = tires
  end

  def start
    @state = "Car is started"
  end

  def stop
    @state = "Car is stoped"  
  end
end

car = Car.new "My enginr", [ 1,2,3,4 ]

car.start
puts car.state

car.stop
puts car.state
