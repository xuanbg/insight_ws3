delete Product_Basic
dbcc checkident(Product_Basic, reseed, 0) 

delete Product_Extend
dbcc checkident(Product_Extend, reseed, 0) 

delete Product_Img
dbcc checkident(Product_Img, reseed, 0) 

delete Product_Library
dbcc checkident(Product_Library, reseed, 0) 

delete Product_Library_Extend
dbcc checkident(Product_Library_Extend, reseed, 0) 

delete Product_Library_Img
dbcc checkident(Product_Library_Img, reseed, 0) 

delete Product_RelateTag
dbcc checkident(Product_RelateTag, reseed, 0) 

