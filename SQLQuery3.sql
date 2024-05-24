SELECT b.*, a.Firstname, a.Lastname 
                                FROM Book b 
                                    JOIN Author a 
                                        ON b.AuthorId = a.AuthorId  
                                WHERE b.Id = 2
