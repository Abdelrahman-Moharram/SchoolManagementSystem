# Summary
The platform enables teachers and students to exchange content related to specific subjects. Administrators have control over creating classrooms and managing registrations, assigning students to classrooms, and adding subjects automatically to all students. Teachers can be added to a classroom based on their specialty and can then add lectures and new content on that particular subject. 

# In this web application we have 4 Controllers 


## Accounts

### Register
There are both Checking form errors
 1) Backend using (Remote, Ajax) with ViewModels
	- <img src="https://github.com/Abdelrahman-Moharram/SchoolManagementSystem/blob/master/SchoolManagementSystem/wwwroot/files/posts/21c07d92-568b-457b-84c8-c92dba99a99e.jpg" width="300px" style="float:left;" >
 	- <img src="https://github.com/Abdelrahman-Moharram/SchoolManagementSystem/blob/master/SchoolManagementSystem/wwwroot/files/posts/2016af59-436c-4925-951d-6a8aa7d57b45.jpg" width="300px" >

 2) Frontend using (JavaScript + jQuery)


    
      
	
### Login
-----

## Admins
### List of All [Subjects, Levels, Subject Category, ClassRooms]
### New Registers
- this get action method shows the new users **not completed** data.
### Modify Student & Add Teacher
- the admin should add, modify, or delete its data as a completed profile.
- creating an account in this app for both (Teachers & Students) is the first step before reviewing the user data from admin to be modified
   1) in the case of **Teacher**
	- Admins should assign Teachers to classroom subjects based on their specialty.
		- so the teacher assigned to a subject is the manager of it and he can't see any subject in the classroom except this subject like the next image student, it shows the difference between students' and teachers' subjects
 		<img src="https://github.com/Abdelrahman-Moharram/SchoolManagementSystem/blob/master/SchoolManagementSystem/wwwroot/files/posts/9243aec7-2cc7-42d8-800c-0c4206891d4e.jpg" width="800px" >
   2) in the case of **students**
   	- Admins should assign students to classrooms, and then classrooms should be added automatically to the students like the left of the previous image.
### Admins can Add [Subject, SubjectCategory, Level, ClassRoom, TeacherToSubjects]
### Filter Classrooms with Level_id
----

## Classrooms 
### is a Controller for students that shows all the Subjects for the logged-in student, and that allows them to show and add posts.
- Subjects
	- Lectures
 		- Posts
----

## Teachers 
### is a Controller for Teachers that shows all the Teachers' Subjects in all classrooms and levels and adds lectures and new content.
- Classrooms
	- Subjects
		- Lectures
 			- Posts
