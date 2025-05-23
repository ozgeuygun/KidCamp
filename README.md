# KidCamp
 
This is a management system that includes camps and activities aimed at children. It has been developed to make it easier for users to reserve and track camps, as well as to manage these processes.

## Admin Panel
It encompasses tasks such as organizing camps and events, adding trainers to camps or activities, and approving comments.

## Member Panel
Parents can make a reservation for a camp or event their child wants to join if their child's age fits the age range for participation. They can save the activities or camps they like to access them easily later and leave comments on the activities they attended.

## Instructor Panel
Instructors can view the camps and events assigned to them and see the list of participants for the relevant activities. They can also download this list in Excel format if they wish.

## Capacity Management
The capacity is automatically updated with each new reservation. When users enter the number of people who will join during the reservation process, this number is deducted from the total capacity. This process is managed by a trigger that we created in the database. The trigger works automatically when a reservation record is added and updates the capacity of the related camp.

### Technologies Used and Technical Features
	
- ASP.NET Core 6.0
- Entity Framework Code First
- MSSQL Server
- Identity
- LINQ
- HTML
- CSS
- JavaScript 
- AJAX
- Bootstrap
- SweetAlert
- Toastr
- N-Tier Architecture
- Repository Design Pattern
- PagedList
- Fluent Validation
- Trigger
  
  
### Home page
![Home Page](https://github.com/ozgeuygun/KidCamp/blob/main/KidCamp/KidCamp/wwwroot/Screenshot/Ana%20Sayfa.png)

### Information
![Information](https://github.com/ozgeuygun/KidCamp/blob/main/KidCamp/KidCamp/wwwroot/Screenshot/bilgi-al.png)

### Member - Activities
![activities](https://github.com/ozgeuygun/KidCamp/blob/main/KidCamp/KidCamp/wwwroot/Screenshot/Aktiviteler.png)

### Member - Login
![login](https://github.com/ozgeuygun/KidCamp/blob/main/KidCamp/KidCamp/wwwroot/Screenshot/Giris.png)

### Member - Reservation
![reservation](https://github.com/ozgeuygun/KidCamp/blob/main/KidCamp/KidCamp/wwwroot/Screenshot/Rezervasyon.png)
![reservation](https://github.com/ozgeuygun/KidCamp/blob/main/KidCamp/KidCamp/wwwroot/Screenshot/uye-bildirim.png)

### Member- Comment
![comment](https://github.com/ozgeuygun/KidCamp/blob/main/KidCamp/KidCamp/wwwroot/Screenshot/Yorum.png)

### Instructor - Participant
![participant](https://github.com/ozgeuygun/KidCamp/blob/main/KidCamp/KidCamp/wwwroot/Screenshot/Katilimcilar.png)
![participant list](https://github.com/ozgeuygun/KidCamp/blob/main/KidCamp/KidCamp/wwwroot/Screenshot/katilimci-listesi.png)

### Admin - Roles
![roles](https://github.com/ozgeuygun/KidCamp/blob/main/KidCamp/KidCamp/wwwroot/Screenshot/Rol.png)

### Admin - Activities
![admin](https://github.com/ozgeuygun/KidCamp/blob/main/KidCamp/KidCamp/wwwroot/Screenshot/admin-aktivite.png)




