# Uni - RESTFUL WEB API

RESTful Web Api to manage a persisted domain model relating to the problem domain of a university where:
* Students enrol in Subjects;
* Subjects are taught through a set of Lectures on a weekly schedule; and
* Each Lecture is delivered in a Lecture Theatre on a given day of the week at a given time for a given duration.
* Each lecture theatre has a nominated capacity.

The persistence mechanism is EF core.

Expose CRUD-style operations for each entity type via the Restful API to supports:
* Creating, reading students
* Creating, reading subjects
* Creating, reading lecture theatres
* Creating, reading lectures on a schedule as sub-resources of a subject, where the lecture theatre is identified as a property of the lecture.
* Reading enrolments as a collection sub-resource of a student resource, returning the list of enrolments
* Reading students as a collection sub-resource of a subject, returning the list of students enrolled in the subject.

Exposed a RESTful api represents the operation of a student enrolling in a subject. When a student enrols in a subject, the following business rules are enforced:

* If the enrolment causes any of the lectures to exceed the capacity of its nominated lecture theatre, the enrolment is rejected
* If the enrolment cause the student to have > 10 hours of lectures in a week, the enrolment is rejected
* If the enrolment is successful, a notification is sent to the student. For now, the notification is simulated by dumping a file to disk.
