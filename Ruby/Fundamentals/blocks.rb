#number = 0
#16.times do |number|
#  puts number
#end
#-------------------------------------------------
#list = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15]
#(0...15).each do |number|
#  puts number
#end
#-------------------------------------------------
#for number in 0..15 do
#  puts number
#end
#-------------------------------------------------
def form &block
  puts "<form>"
  yield
  puts"</form>"
end

def paragraph text
  puts "<p>"+text+"</p>"
end

form do
  paragraph "ololo"
end




