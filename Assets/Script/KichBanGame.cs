// Đây là 1 tựa game thủ thành top down 2D
//dựa theo ý tưởng từ tựa game ThroneFall trên steam 
//Đối tượng trong trò chơi : Hall (nhà chính ) ,king(queen) , Nhà máy sản xuất tài nguyên (gold mine , silver mine , good mine) ,
//tháp phòng thủ ,nhà lính , quái vật (minions ) , tường thành 
//Cơ chế game : + xây dựng theo cơ chế ngày đêm : ban ngày xây dựng thành trì  , ban đêm phòng thủ trước các đợt tấn công
//              của địch 
//              + Xây dựng thành trì dựa vào số tiền có được sau mỗi đêm phòng thủ thành công (mặc định lúc đầu cho 5 vàng để
//              xây nhà chính và 1 tháp phòng thủ / nhà máy sản xuất tài nguyên )
//              + Giá tiền : nhà chính (2 vàng ) : bị phá là thua , chỉ xây dựng 1 lần đầu game , có khả năng nâng cấp (bằng vàng) 
//              Ý tưởng thêm nếu có thể : mỗi lần nâng cấp sẽ cho chọn thẻ có tác dụng tùy vào phong cách người chơi
//              + người chơi ngoài việc xây dụng đội hình có thể trực tiếp tham gia vào trận mạc ( bằng cách điều khiển
//              king / queen đến nơi giao chiến)
//              + Dự kiến xây dựng trò chơi có nhiều map , mỗi map có 4 day (4 ngày và 4 đêm ) , đêm cuối gặp boss
//              + Tất cả các đối tượng trong chò trơi đều có 2 giá trị (vàng,máu) , riêng các đối tượng di chuyển thì có thêm giá
//              trị dame  
