USE [DevBookLibrary]
GO
DELETE FROM [dbo].[books]
GO
SET IDENTITY_INSERT [dbo].[books] ON 
GO
INSERT [dbo].[books] ([book_id], [title], [first_name], [last_name], [total_copies], [copies_in_use], [type], [isbn], [category]) VALUES (1, N'Pride and Prejudice', N'Jane', N'Austen', 100, 80, N'Hardcover', N'1234567891', N'Fiction')
GO
INSERT [dbo].[books] ([book_id], [title], [first_name], [last_name], [total_copies], [copies_in_use], [type], [isbn], [category]) VALUES (2, N'To Kill a Mockingbird', N'Harper', N'Lee', 75, 65, N'Paperback', N'1234567892', N'Fiction')
GO
INSERT [dbo].[books] ([book_id], [title], [first_name], [last_name], [total_copies], [copies_in_use], [type], [isbn], [category]) VALUES (3, N'The Catcher in the Rye', N'J.D.', N'Salinger', 50, 45, N'Hardcover', N'1234567893', N'Fiction')
GO
INSERT [dbo].[books] ([book_id], [title], [first_name], [last_name], [total_copies], [copies_in_use], [type], [isbn], [category]) VALUES (4, N'The Great Gatsby', N'F. Scott', N'Fitzgerald', 50, 22, N'Hardcover', N'1234567894', N'Non-Fiction')
GO
INSERT [dbo].[books] ([book_id], [title], [first_name], [last_name], [total_copies], [copies_in_use], [type], [isbn], [category]) VALUES (5, N'The Alchemist', N'Paulo', N'Coelho', 50, 35, N'Hardcover', N'1234567895', N'Biography')
GO
INSERT [dbo].[books] ([book_id], [title], [first_name], [last_name], [total_copies], [copies_in_use], [type], [isbn], [category]) VALUES (6, N'The Book Thief', N'Markus', N'Zusak', 75, 11, N'Hardcover', N'1234567896', N'Mystery')
GO
INSERT [dbo].[books] ([book_id], [title], [first_name], [last_name], [total_copies], [copies_in_use], [type], [isbn], [category]) VALUES (7, N'The Chronicles of Narnia', N'C.S.', N'Lewis', 100, 14, N'Paperback', N'1234567897', N'Sci-Fi')
GO
INSERT [dbo].[books] ([book_id], [title], [first_name], [last_name], [total_copies], [copies_in_use], [type], [isbn], [category]) VALUES (8, N'The Da Vinci Code', N'Dan', N'Brown', 50, 40, N'Paperback', N'1234567898', N'Sci-Fi')
GO
INSERT [dbo].[books] ([book_id], [title], [first_name], [last_name], [total_copies], [copies_in_use], [type], [isbn], [category]) VALUES (9, N'The Grapes of Wrath', N'John', N'Steinbeck', 50, 35, N'Hardcover', N'1234567899', N'Fiction')
GO
INSERT [dbo].[books] ([book_id], [title], [first_name], [last_name], [total_copies], [copies_in_use], [type], [isbn], [category]) VALUES (10, N'The Hitchhiker''s Guide to the Galaxy', N'Douglas', N'Adams', 50, 35, N'Paperback', N'1234567900', N'Non-Fiction')
GO
INSERT [dbo].[books] ([book_id], [title], [first_name], [last_name], [total_copies], [copies_in_use], [type], [isbn], [category]) VALUES (11, N'Moby-Dick', N'Herman', N'Melville', 30, 8, N'Hardcover', N'8901234567', N'Fiction')
GO
INSERT [dbo].[books] ([book_id], [title], [first_name], [last_name], [total_copies], [copies_in_use], [type], [isbn], [category]) VALUES (12, N'To Kill a Mockingbird', N'Harper', N'Lee', 20, 0, N'Paperback', N'9012345678', N'Non-Fiction')
GO
INSERT [dbo].[books] ([book_id], [title], [first_name], [last_name], [total_copies], [copies_in_use], [type], [isbn], [category]) VALUES (13, N'The Catcher in the Rye', N'J.D.', N'Salinger', 10, 1, N'Hardcover', N'0123456789', N'Non-Fiction')
GO
SET IDENTITY_INSERT [dbo].[books] OFF
GO
