# Multitier architecture project. Daily car rental simulation.  
  
Mar 17, 2021  
- Fixed GetImagesByCarId method.  
- Add "get car details by brand" method.  
- Add "get car details by color" method.  
  
Mar 5, 2021  
- Authorization system added.  
- JWT integration added.  
- Cache Aspect added.  
- Transaction Aspect added.  
- Performance Aspect added.  
  
Feb 28, 2021  
- Add CarImages table.  
- Add a picture to the car via the WebAPI.  
- Pictures stored with GUID.  
- Image deletion, update capabilities added.  
- A car can have up to 5 images.  
- The date of the picture upload is determined automatically.  
- The default image is shown for vehicles without photos.  
  
Feb 20, 2021  
- "AOP" support added.  
- ValidationAspect added.  
- "FluentValidation" support added.  
- "Autofac" support added.  
  
Feb 15, 2021  
- "WebAPI" layer was established.  
- All services in the business layer were written for APIs.  
- GetById method added for rentals.  
  
Feb 14, 2021  
- "Results" configuration created in "Core" layer.  
- "Business" classes have been refactored.  
- Created "Users" table.  
- Created "Customers" table.  
- Created "Rentals" table.  
- The necessary conditions have been added for renting a car.  
  
Feb 7, 2021  
- Fixed GetById method and made available for each object.  
- Globel Core layer added.  
- Some universal interfaces moved to the Core layer.  
- Dto used.  
- Added all CRUD operations for Car, Brand and Color objects.  
- GetCarDetails method was added by joining 3 tables in the database.  
- GetCarDetails method is used in program.cs.  
  
Feb 5, 2021  
- Car update method added.  
- Adding each method's sample usage to Program.cs  
  
Feb 4, 2021  
- Brand and Color objects have been added.  
- EntityFramework added.  
- GetCarsByBrandId and GetCarsByColorId methods added.  
- Some conditions have been added to add vehicles to the database.  
  
Feb 1, 2021  
- Add project files.  
