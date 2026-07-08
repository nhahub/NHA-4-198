🎓 Center Education Management System
📌 Project Description
The Center Education Management System is a web-based platform designed to manage educational centers efficiently. It supports multiple roles including Super Admin, Center Owner, Center Admin, Teachers, Assistants, Students, Parents, and Visitors.

The system handles:

Center registration & verification
Subscription management
Student enrollment
Staff management
Group scheduling
Attendance tracking
Exam lifecycle
Content delivery
Payments
Reports & analytics
👑 1. Super Admin — User Stories
Account & Center Management
US-SA-001 Create center accounts

US-SA-002 Suspend center accounts

US-SA-003 Delete center accounts

US-SA-004 Review Center Owner registration requests

US-SA-005 Approve / reject identity documents

Subscription Management
US-SA-006 Approve center subscriptions

US-SA-007 Change subscription plans (Free / Basic / Pro / Enterprise)

US-SA-008 Suspend unpaid centers

US-SA-009 Reactivate centers after payment

Revenue Monitoring
US-SA-010 View revenue reports

🏢 2. Center Owner — User Stories
Subscription Control
US-CO-001 Choose subscription plan

US-CO-002 Renew subscription

US-CO-003 Upgrade / downgrade plan

US-CO-004 Track subscription status

Payment Integration
US-CO-005 Manage payment details

US-CO-006 Connect payment gateways

(Paymob / Fawry / Instapay / Visa)

Admin Management
US-CO-007 Create Center Admin accounts

US-CO-008 Assign permissions to admins

🧑‍💼 3. Center Admin — User Stories
Student Management
US-CA-001 Register students

US-CA-002 Review join requests

US-CA-003 Edit student data

US-CA-004 Transfer students between groups

Staff Management
US-CA-005 Add teachers

US-CA-006 Add assistants

US-CA-007 Edit teacher and assistant data

US-CA-008 Assign teachers and assistants to groups

Group Management
US-CA-009 Create groups

US-CA-010 Assign teachers to groups

US-CA-011 Define schedules

US-CA-012 Assign classrooms

US-CA-013 Define group capacity

US-CA-014 Set group pricing

Payment Management
US-CA-015 Record cash payments

US-CA-016 Issue receipts

US-CA-017 Apply discounts

US-CA-018 Track delayed payments

US-CA-019 Block unpaid students

👨‍🏫 4. Teacher — User Stories
Session Management
US-T-001 Teach assigned groups

US-T-002 View schedule

US-T-003 See classroom assignments

US-T-004 View student count per group

Attendance Control
US-T-005 Record attendance

US-T-006 Postpone sessions

US-T-007 Cancel and reschedule sessions

Teacher Replacement Scenario
US-T-008 Preserve academic history after teacher departure

US-T-009 Disable removed teacher permissions with logs retained

Content Uploading
US-T-010 Upload session videos

US-T-011 Upload PDFs

US-T-012 Upload board images

US-T-013 Attach Drive links

US-T-014 Control content visibility per group

Student Approval
US-T-015 Approve join requests

US-T-016 Reject unsuitable requests

Exam Creation
US-T-017 Create quizzes and exams

US-T-018 Define exam duration

US-T-019 Define grading values

US-T-020 Control result visibility timing

Question Bank Management
US-T-021 Create question bank entries

US-T-022 Classify questions by lesson

US-T-023 Reuse questions later

Manual Grade Entry
US-T-024 Enter paper exam grades manually

👨‍💻 5. Teacher Assistant — User Stories
Attendance Management
US-TA-001 Record attendance manually

US-TA-002 Edit attendance records

US-TA-003 Track absent students

QR Attendance System
US-TA-004 Generate rotating QR codes

US-TA-005 Refresh QR tokens every 30 seconds

US-TA-006 Validate attendance against membership & payment

Academic Support Tasks
US-TA-007 Upload session materials

US-TA-008 Enter offline exam grades

US-TA-009 Approve/reject join requests (if authorized)

🎓 6. Student — User Stories
Registration
US-ST-001 Create account

Center Selection
US-ST-002 Browse centers

US-ST-003 Submit join requests

Group Enrollment
US-ST-004 Select subject / teacher / group

US-ST-005 Validate group capacity automatically

Attendance
US-ST-006 Scan QR attendance

Content Access
US-ST-007 Access session materials

US-ST-008 Restrict access if subscription expires

Exams
US-ST-009 Take online exams

US-ST-010 Automatic answer saving

Grade Tracking
US-ST-011 View grades

Attendance Tracking
US-ST-012 View attendance logs

Payment Tracking
US-ST-013 View invoices and receipts

👨‍👩‍👦 7. Parent — User Stories
US-P-001 Link child account

US-P-002 Track attendance

US-P-003 Receive absence alerts

US-P-004 Monitor grades

US-P-005 Track payments

US-P-006 Receive payment reminders

🌍 8. Marketplace Visitors — User Stories
US-L-001 Browse centers without login

US-L-002 Filter centers by:

Location
Subject
Teacher
Rating
Price
Schedule
US-L-003 View teacher profiles

🧪 9. Exam System Lifecycle — User Stories
Exam Preparation
US-EX-001 Define subject, grade, duration

US-EX-002 Generate exams dynamically

Randomization
US-EX-003 Controlled randomness

US-EX-004 Shuffle questions

US-EX-005 Shuffle answer options

Anti-Cheating
US-EX-006 Unique exam instance per student

US-EX-007 One attempt per student

Reliability
US-EX-008 Auto-save answers

US-EX-009 Resume exam after reconnection

US-EX-010 Exam snapshot locking

Grading
US-EX-011 Automatic grading

US-EX-012 Manual essay grading

Analytics
US-EX-013 Performance analytics

US-EX-014 Exam difficulty analysis
