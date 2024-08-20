<template>
    <div class="page-content">
        <div class="m-page-header">
            <div class="m-page-title">Danh sách nhân viên</div>
            <div class="m-page-button">
                <button id="btnadd" @click="bntAddOnClick" class="m-btn m-btn-icon m-icon-add m-icon-16px">Thêm nhân viên mới</button>               
            </div>
        </div>
        <div class="m-page-tolbar"> 
            <div class="m-tolbar-left">
                <div class="left-item">
                    <input type="text" style="width: 300px" class="m-input m-input-icon m-icon-search" placeholder="Tìm kiếm theo mã, tên hoặc số điện thoại">        
                </div>
                <div class="left-item">
                    <select name="" id="">
                        <option value="">Tất cả phòng ban</option>
                        <option value="">Phòng nhân sự</option>
                        <option value="">Phòng kế toán</option>
                    </select>                    
                </div>
                <div class="left-item">
                    <select name="" id="">
                        <option value="">Tất cả vị trí</option>
                        <option value="">Quản lý</option>
                        <option value="">Nhân viên</option>
                    </select>
                </div>
            </div>
            <div class="m-tolbar-right"> 
                <button class="btn-res"></button>
            </div>
        </div>  
        <div class="m-page-grid">
            <div class="m-table-conten">
                <table class="m-table">
                <thead>
                    <tr >
                        <th class="text-align-left" style="width: 100px;">Mã nhân viên</th>
                        <th class="text-align-left">Họ và tên</th>
                        <th class="text-align-left" style="width: 69px">Giới tính</th>
                        <th class="text-align-center">Ngày sinh</th>
                        <th class="text-align-left">Điện thoại</th>
                        <th class="text-align-left" style="width: 100px;">Email</th>
                        <th class="text-align-left" style="width: 69px;">Chức vụ</th>
                        <th class="text-align-left" style="width: 120px;">Phòng ban</th>
                        <th class="text-align-right" style="width: 130px;">Mức lương cơ bản</th>
                        <th class="text-align-left" style="width: 140px;">Tình trạng công việc</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="employee in employees" :key="employee.EmployeeId">
                        <td class="text-align-left" >{{employee.EmployeeCode}}</td>
                        <td class="text-align-left" style="width: 110px">{{employee.FullName}}</td>
                        <td class="text-align-left" style="width: 50px">{{employee.Gender}}</td>
                        <td class="text-align-center">{{formatDate(employee.DateOfBirth)}}</td>
                        <td class="text-align-left">{{employee.PhoneNumber}}</td>
                        <td class="text-align-left">{{employee.Email}}</td>
                        <td class="text-align-left">{{employee.PositionName}}</td>
                        <td class="text-align-left">{{employee.DepartmentName}}</td>
                        <td class="text-align-right">{{employee.Salary}}</td>
                        <td class="text-align-left">{{employee.WorkStatus}}</td>
                    </tr>
                </tbody>
            </table>       
            </div>    
            <div class="m-paging">
                <div class="m-paging-left">Hiển thị 01 - 100/200 nhân viên</div>
                <div class="m-paging-center">
                    <button class="m-btn-first m-icon m-icon-first"></button>
                    <button class="m-btn-prev m-icon m-icon-prev"></button>
                    <div class="m-page-number-group">
                        <button class="m-page-number m-page-number-selected">1</button>
                        <button class="m-page-number">2</button>
                        <button class="m-page-number">3</button>
                        <button class="m-page-number">4</button>
                    </div>
                    <button class="m-btn-next m-icon m-icon-next"></button>
                    <button class="m-btn-last m-icon m-icon-last"></button>
                </div>
                <div class="m-paging-right">
                    <div style="color: black;">10 Nhân viên trên trang</div>                 
                </div>  
            </div>
        </div>
    </div>
    <EmployeeDetail/>
</template>

<script>
    import axios from 'axios'
    import EmployeeDetail from './EmployeeDetail.vue';
    export default{
        name: "EmployeeList",
        components:{
            EmployeeDetail,
        },


        setup(){ 
            console.log("BeforeCreated")
        },
         
        created() {
            try{
                var me = this;
                console.log("created")
                axios
                .get("https://cukcuk.manhnv.net/api/v1/Employees")
                .then((response) => {
                    console.log(response.data);
                    me.employees = response.data;
                })
                .catch((response) => {
                    console.log(response.data);
                }); 
            }
            catch(error){
                console.log(error);
            } 
        },

        methods: {
            formatDate(dob) {
            if (dob) {
                dob = new Date(dob);
                let date = dob.getDate();
                date = date < 10 ? `0${date}` : date; // Use backticks for template literals
                let month = dob.getMonth() + 1;
                month = month < 10 ? `0${month}` : month; // Use backticks for template literals
                let year = dob.getFullYear();
                dob = `${date}/${month}/${year}`; // Use backticks for template literals
            } else {
                dob = "";
            }
            return dob;
            },

            bntAddOnClick() {
                document.getElementById("dialog").style.display = "block";
            }

        },

        data() {
            return {
                employees: null,
            };
        },
    
    }
</script>