-- INSERT INTO Product (category_id, name, description, price, stock, image_url, status)
-- VALUES (1, 'Basic White T-Shirt', 'Unisex cotton crewneck white T-shirt.', 9.99, 120, 'https://images.pexels.com/photos/12039633/pexels-photo-12039633.jpeg', 'Active');

-- INSERT INTO Product (category_id, name, description, price, stock, image_url, status)
-- VALUES (1, 'Black Oversized Hoodie', 'Soft and warm oversized fleece hoodie.', 29.99, 80, 'https://images.pexels.com/photos/28466774/pexels-photo-28466774.jpeg', 'Active');

-- INSERT INTO Product (category_id, name, description, price, stock, image_url, status)
-- VALUES (2, 'Blue Denim Jeans', 'Straight-cut blue denim jeans for everyday wear.', 39.90, 60, 'https://images.pexels.com/photos/34708142/pexels-photo-34708142.jpeg', 'Active');

-- INSERT INTO Product (category_id, name, description, price, stock, image_url, status)
-- VALUES (2, 'Slim Fit Chinos', 'Casual slim-fit chinos in beige color.', 34.50, 50, 'https://images.pexels.com/photos/5851033/pexels-photo-5851033.jpeg', 'Active');

-- INSERT INTO Product (category_id, name, description, price, stock, image_url, status)
-- VALUES (3, 'Floral Summer Dress', 'Lightweight floral print summer dress.', 27.80, 45, 'https://images.pexels.com/photos/1721944/pexels-photo-1721944.jpeg', 'Active');

-- INSERT INTO Product (category_id, name, description, price, stock, image_url, status)
-- VALUES (1, 'Graphic Tee Streetwear', 'Street-style graphic T-shirt, soft cotton fabric.', 15.90, 100, 'https://images.pexels.com/photos/19875323/pexels-photo-19875323.jpeg', 'Active');

-- INSERT INTO Product (category_id, name, description, price, stock, image_url, status)
-- VALUES (3, 'Casual Sneakers', 'Comfortable everyday sneakers, breathable fabric.', 49.00, 40, 'https://images.pexels.com/photos/34720486/pexels-photo-34720486.jpeg', 'Active');

-- INSERT INTO Product (category_id, name, description, price, stock, image_url, status)
-- VALUES (2, 'Short Sleeve Polo Shirt', 'Classic men’s polo shirt in navy blue.', 22.50, 70, 'https://images.pexels.com/photos/34149706/pexels-photo-34149706.jpeg', 'Active');

-- INSERT INTO Product (category_id, name, description, price, stock, image_url, status)
-- VALUES (3, 'Women Cardigan', 'Soft knitted cardigan, perfect for layering.', 32.90, 35, 'https://images.pexels.com/photos/5931609/pexels-photo-5931609.jpeg', 'Active');

-- INSERT INTO Product (category_id, name, description, price, stock, image_url, status)
-- VALUES (1, 'Baseball Cap', 'Adjustable cotton baseball cap for casual wear.', 12.00, 150, 'https://images.pexels.com/photos/1124465/pexels-photo-1124465.jpeg', 'Active');


-- Main Categories
-- INSERT INTO Category (name, description, parent_category_id)
-- VALUES ('Men', 'Men clothing and fashion items.', NULL);

-- INSERT INTO Category (name, description, parent_category_id)
-- VALUES ('Women', 'Women clothing and fashion items.', NULL);

-- INSERT INTO Category (name, description, parent_category_id)
-- VALUES ('Accessories', 'Fashion accessories for all genders.', NULL);

-- -- Subcategories - Men
-- INSERT INTO Category (name, description, parent_category_id)
-- VALUES ('Men T-Shirts', 'Casual T-shirts for men.', 1);

-- INSERT INTO Category (name, description, parent_category_id)
-- VALUES ('Men Jeans', 'Denim jeans for men.', 1);

-- INSERT INTO Category (name, description, parent_category_id)
-- VALUES ('Men Shoes', 'Footwear and sneakers for men.', 1);

-- -- Subcategories - Women
-- INSERT INTO Category (name, description, parent_category_id)
-- VALUES ('Women Dresses', 'Casual and party dresses for women.', 2);

-- INSERT INTO Category (name, description, parent_category_id)
-- VALUES ('Women Tops', 'Casual tops and blouses for women.', 2);

-- INSERT INTO Category (name, description, parent_category_id)
-- VALUES ('Women Shoes', 'Sneakers, sandals, and heels for women.', 2);

-- -- Subcategories - Accessories
-- INSERT INTO Category (name, description, parent_category_id)
-- VALUES ('Hats & Caps', 'Fashion hats and caps for casual outfits.', 3);


-- INSERT INTO user_account (fullname, email, hashed_password, phone, address, status)
-- VALUES ('Nguyen Van A', 'vana@example.com', 'hashed_pw_123abc', '0901234567', '123 Nguyen Trai, District 1, HCMC', 'Active');

-- INSERT INTO user_account (fullname, email, hashed_password, phone, address, status)
-- VALUES ('Tran Thi B', 'thib@example.com', 'hashed_pw_456def', '0912345678', '45 Tran Hung Dao, District 5, HCMC', 'Active');

-- INSERT INTO user_account (fullname, email, hashed_password, phone, address, status)
-- VALUES ('Le Minh C', 'minhc@example.com', 'hashed_pw_789ghi', '0987654321', '78 Vo Van Tan, District 3, HCMC', 'Active');

-- INSERT INTO user_account (fullname, email, hashed_password, phone, address, status)
-- VALUES ('Pham Quynh D', 'quynhd@example.com', 'hashed_pw_135jkl', '0978111222', '22 Le Loi, District 1, HCMC', 'Inactive');

-- INSERT INTO user_account (fullname, email, hashed_password, phone, address, status)
-- VALUES ('Hoang Tuan E', 'tuane@example.com', 'hashed_pw_246mno', '0909988776', '56 Cach Mang Thang 8, District 10, HCMC', 'Active');

-- INSERT INTO employee (fullName, email, hashed_password, role, status) VALUES
-- ('Anna Nguyen', 'anna.nguyen@fashionshop.com', '1a79a4d60de6718e8e5b326e338ae533', 'Admin', 'Active');

-- INSERT INTO employee (fullName, email, hashed_password, role, status) VALUES
-- ('David Tran', 'david.tran@fashionshop.com', '5f4dcc3b5aa765d61d8327deb882cf99', 'Staff', 'Active');

-- INSERT INTO employee (fullName, email, hashed_password, role, status) VALUES
-- ('Linh Pham', 'linh.pham@fashionshop.com', '6cb75f652a9b52798eb6cf2201057c73', 'Staff', 'Active');

-- INSERT INTO employee (fullName, email, hashed_password, role, status) VALUES
-- ('Michael Le', 'michael.le@fashionshop.com', '7c222fb2927d828af22f592134e8932480637c0d', 'Manager', 'Active');

-- INSERT INTO employee (fullName, email, hashed_password, role, status) VALUES
-- ('Jenny Ho', 'jenny.ho@fashionshop.com', 'e99a18c428cb38d5f260853678922e03', 'Staff', 'Inactive');

-- INSERT INTO voucher (code, description, discount_percent, discount_amount, start_date, end_date, quantity, status)
-- VALUES ('WELCOME10', '10% off for new customers', 10.00, NULL, '2025-11-01', '2025-12-31', 100, 'Active');

-- INSERT INTO voucher (code, description, discount_percent, discount_amount, start_date, end_date, quantity, status)
-- VALUES ('FALL50K', '50,000 VND off orders over 500,000 VND', NULL, 50000, '2025-11-10', '2025-11-30', 200, 'Active');

-- INSERT INTO voucher (code, description, discount_percent, discount_amount, start_date, end_date, quantity, status)
-- VALUES ('BLACKFRIDAY20', '20% off Black Friday sale', 20.00, NULL, '2025-11-25', '2025-11-30', 500, 'Active');

-- INSERT INTO voucher (code, description, discount_percent, discount_amount, start_date, end_date, quantity, status)
-- VALUES ('FREESHIP', 'Free shipping for orders above 300,000 VND', NULL, 0, '2025-11-01', '2025-12-31', 1000, 'Active');

-- INSERT INTO voucher (code, description, discount_percent, discount_amount, start_date, end_date, quantity, status)
-- VALUES ('CYBERMONDAY15', '15% off Cyber Monday exclusive', 15.00, NULL, '2025-11-29', '2025-11-29', 300, 'Active');

-- INSERT INTO orders (user_id, employee_id, voucher_id, order_date, total_amount, final_amount, payment_method, payment_status, shipping_status, shipping_address)
-- VALUES (1, 2, 1, '2025-11-01 10:15:00', 250000, 225000, 'Credit Card', 'Paid', 'Shipped', '123 Nguyen Trai, District 1, HCMC');

-- INSERT INTO orders (user_id, employee_id, voucher_id, order_date, total_amount, final_amount, payment_method, payment_status, shipping_status, shipping_address)
-- VALUES (2, NULL, NULL, '2025-11-02 14:30:00', 500000, 500000, 'Cash on Delivery', 'Pending', 'Pending', '45 Tran Hung Dao, District 5, HCMC');

-- INSERT INTO orders (user_id, employee_id, voucher_id, order_date, total_amount, final_amount, payment_method, payment_status, shipping_status, shipping_address)
-- VALUES (3, 3, 2, '2025-11-03 09:45:00', 750000, 700000, 'Credit Card', 'Paid', 'Delivered', '78 Vo Van Tan, District 3, HCMC');

-- INSERT INTO orders (user_id, employee_id, voucher_id, order_date, total_amount, final_amount, payment_method, payment_status, shipping_status, shipping_address)
-- VALUES (4, 1, 3, '2025-11-04 11:20:00', 120000, 96000, 'Momo', 'Paid', 'Delivered', '22 Le Loi, District 1, HCMC');

-- INSERT INTO orders (user_id, employee_id, voucher_id, order_date, total_amount, final_amount, payment_method, payment_status, shipping_status, shipping_address)
-- VALUES (5, NULL, NULL, '2025-11-05 16:50:00', 300000, 300000, 'Cash on Delivery', 'Pending', 'Pending', '56 Cach Mang Thang 8, District 10, HCMC');

-- INSERT INTO orders (user_id, employee_id, voucher_id, order_date, total_amount, final_amount, payment_method, payment_status, shipping_status, shipping_address)
-- VALUES (1, 4, 4, '2025-11-06 13:15:00', 400000, 400000, 'Credit Card', 'Paid', 'Shipped', '123 Nguyen Trai, District 1, HCMC');

-- INSERT INTO orders (user_id, employee_id, voucher_id, order_date, total_amount, final_amount, payment_method, payment_status, shipping_status, shipping_address)
-- VALUES (2, 2, 1, '2025-11-07 10:00:00', 550000, 495000, 'Credit Card', 'Paid', 'Delivered', '45 Tran Hung Dao, District 5, HCMC');

-- INSERT INTO orders (user_id, employee_id, voucher_id, order_date, total_amount, final_amount, payment_method, payment_status, shipping_status, shipping_address)
-- VALUES (3, NULL, NULL, '2025-11-08 15:40:00', 200000, 200000, 'Cash on Delivery', 'Pending', 'Pending', '78 Vo Van Tan, District 3, HCMC');

-- INSERT INTO orders (user_id, employee_id, voucher_id, order_date, total_amount, final_amount, payment_method, payment_status, shipping_status, shipping_address)
-- VALUES (4, 5, 5, '2025-11-09 09:30:00', 600000, 510000, 'Credit Card', 'Paid', 'Shipped', '22 Le Loi, District 1, HCMC');

-- INSERT INTO orders (user_id, employee_id, voucher_id, order_date, total_amount, final_amount, payment_method, payment_status, shipping_status, shipping_address)
-- VALUES (5, 3, NULL, '2025-11-10 18:25:00', 350000, 350000, 'Momo', 'Paid', 'Delivered', '56 Cach Mang Thang 8, District 10, HCMC');

-- INSERT INTO orders (user_id, employee_id, voucher_id, order_date, total_amount, final_amount, payment_method, payment_status, shipping_status, shipping_address)
-- VALUES (1, NULL, 2, '2025-11-11 12:10:00', 450000, 420000, 'Credit Card', 'Paid', 'Shipped', '123 Nguyen Trai, District 1, HCMC');

-- INSERT INTO orders (user_id, employee_id, voucher_id, order_date, total_amount, final_amount, payment_method, payment_status, shipping_status, shipping_address)
-- VALUES (2, 1, NULL, '2025-11-12 14:55:00', 700000, 700000, 'Cash on Delivery', 'Pending', 'Pending', '45 Tran Hung Dao, District 5, HCMC');

-- INSERT INTO orders (user_id, employee_id, voucher_id, order_date, total_amount, final_amount, payment_method, payment_status, shipping_status, shipping_address)
-- VALUES (3, 2, 3, '2025-11-13 09:05:00', 300000, 240000, 'Credit Card', 'Paid', 'Delivered', '78 Vo Van Tan, District 3, HCMC');

-- INSERT INTO orders (user_id, employee_id, voucher_id, order_date, total_amount, final_amount, payment_method, payment_status, shipping_status, shipping_address)
-- VALUES (4, NULL, 4, '2025-11-14 16:40:00', 500000, 500000, 'Momo', 'Paid', 'Shipped', '22 Le Loi, District 1, HCMC');

-- INSERT INTO orders (user_id, employee_id, voucher_id, order_date, total_amount, final_amount, payment_method, payment_status, shipping_status, shipping_address)
-- VALUES (5, 5, 5, '2025-11-15 11:50:00', 650000, 552500, 'Credit Card', 'Paid', 'Delivered', '56 Cach Mang Thang 8, District 10, HCMC');

-- Order 1
-- INSERT INTO order_item (order_id, product_id, quantity, unit_price, total_price)
-- VALUES (1, 1, 2, 9.99, 19.98),
--        (1, 7, 1, 49.00, 49.00);

-- -- Order 2
-- INSERT INTO order_item (order_id, product_id, quantity, unit_price, total_price)
-- VALUES (2, 2, 1, 29.99, 29.99),
--        (2, 4, 2, 34.50, 69.00);

-- -- Order 3
-- INSERT INTO order_item (order_id, product_id, quantity, unit_price, total_price)
-- VALUES (3, 3, 1, 39.90, 39.90),
--        (3, 6, 1, 32.90, 32.90);

-- -- Order 4
-- INSERT INTO order_item (order_id, product_id, quantity, unit_price, total_price)
-- VALUES (4, 5, 1, 27.80, 27.80);

-- -- Order 5
-- INSERT INTO order_item (order_id, product_id, quantity, unit_price, total_price)
-- VALUES (5, 8, 3, 22.50, 67.50);

-- -- Order 6
-- INSERT INTO order_item (order_id, product_id, quantity, unit_price, total_price)
-- VALUES (6, 2, 1, 29.99, 29.99),
--        (6, 3, 2, 39.90, 79.80);

-- -- Order 7
-- INSERT INTO order_item (order_id, product_id, quantity, unit_price, total_price)
-- VALUES (7, 1, 1, 9.99, 9.99),
--        (7, 9, 1, 32.90, 32.90),
--        (7, 10, 2, 12.00, 24.00);

-- -- Order 8
-- INSERT INTO order_item (order_id, product_id, quantity, unit_price, total_price)
-- VALUES (8, 4, 1, 34.50, 34.50);

-- -- Order 9
-- INSERT INTO order_item (order_id, product_id, quantity, unit_price, total_price)
-- VALUES (9, 7, 1, 49.00, 49.00),
--        (9, 6, 1, 32.90, 32.90);

-- -- Order 10
-- INSERT INTO order_item (order_id, product_id, quantity, unit_price, total_price)
-- VALUES (10, 5, 2, 27.80, 55.60),
--        (10, 1, 1, 9.99, 9.99);

-- -- Order 11
-- INSERT INTO order_item (order_id, product_id, quantity, unit_price, total_price)
-- VALUES (11, 8, 2, 22.50, 45.00);

-- -- Order 12
-- INSERT INTO order_item (order_id, product_id, quantity, unit_price, total_price)
-- VALUES (12, 2, 1, 29.99, 29.99),
--        (12, 3, 1, 39.90, 39.90);

-- -- Order 13
-- INSERT INTO order_item (order_id, product_id, quantity, unit_price, total_price)
-- VALUES (13, 9, 1, 32.90, 32.90);

-- -- Order 14
-- INSERT INTO order_item (order_id, product_id, quantity, unit_price, total_price)
-- VALUES (14, 10, 2, 12.00, 24.00),
--        (14, 7, 1, 49.00, 49.00);

-- -- Order 15
-- INSERT INTO order_item (order_id, product_id, quantity, unit_price, total_price)
-- VALUES (15, 1, 1, 9.99, 9.99),
--        (15, 5, 2, 27.80, 55.60),
--        (15, 3, 1, 39.90, 39.90);
