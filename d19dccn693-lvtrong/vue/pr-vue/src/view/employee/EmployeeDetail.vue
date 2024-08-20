<template>
    <div class="m-dialog" id="dialog">
            <div class="m-dialog-header">
                <div class="d-header-text">THÔNG TIN NHÂN VIÊN</div>
                <button 
                    id="closeDialog"
                    @click="closeOnClick"
                    class="d-header-icon m-icon m-icon-x"></button>
            </div>
            <div class="m-dialog-body">
                <div class="body-left">
                    <div class="b-left-img m-icon-acc" ></div>
                    <div class="b-left-text">(Vui lòng chọn ảnh có định dạng .jpg. .jpeg. .png. .gif.)</div>
                </div>
                <div class="body-right">
                    <div >A. Thông tin chung</div>
                    <div class="body-line"></div>
                    <div class="r-input">
                        <div class="r-info">
                            <div class="info-label">Mã nhân viên (<span style="color: red;">*</span>)</div>
                            <div class="info-context">
                                <input type="text" style="width: 250px" class="m-input" placeholder="Nhập mã sinh viên">       
                            </div>
                        </div>
                        <div class="r-info">
                            <div class="info-label">Họ và tên (<span style="color: red;">*</span>)</div>
                            <div class="info-context">
                                <input type="text" style="width: 250px" class="m-input" placeholder="Nhập họ và tên">       
                            </div>
                        </div>
                    </div>
                    <div class="r-input">
                        <div class="r-info">
                            <div class="info-label">Ngày sinh</div>
                            <div class="info-context">
                                <input type="text" style="width: 250px" class="m-input m-input-icon-right m-icon-calender m-icon-16px   " placeholder="Nhập ngày sinh">        
                            </div>
                        </div>
                        <div class="r-info">
                            <div class="info-label">Giới tính</div>
                            <div class="info-context">
                                <select style="width: 250px; font-size: 13px;" name="" id="">
                                    <option value="">Nam</option>
                                    <option value="">Nữ</option>
                                </select>                    
                            </div>
                        </div>
                    </div>
                    <div class="r-input">
                        <div class="r-info">
                            <div class="info-label">Số CMTNH/Căn cước (<span style="color: red;">*</span>)</div>
                            <div class="info-context">
                                <input type="text" style="width: 250px" class="m-input" placeholder="Nhập số CMTNH/Căn cước">       
                            </div>
                        </div>
                        <div class="r-info">
                            <div class="info-label">Ngày cấp</div>
                            <div class="info-context">
                                <input type="text" style="width: 250px" class="m-input m-input-icon-right m-icon-calender m-icon-16px   " placeholder="Nhập ngày cấp">        
                            </div>
                        </div>
                    </div>
                    <div class="r-input">
                        <div class="r-info">
                            <div class="info-label">Nơi cấp</div>
                            <div class="info-context">
                                <input type="text" style="width: 250px" class="m-input" placeholder="Nhập nơi cấp">       
                            </div>
                        </div>
                    </div>
                    <div class="r-input">
                        <div class="r-info">
                            <div class="info-label">Email (<span style="color: red;">*</span>)</div>
                            <div class="info-context">
                                <input type="text" style="width: 250px" class="m-input" placeholder="Nhập email">       
                            </div>
                        </div>
                        <div class="r-info">
                            <div class="info-label">Số điện thoại (<span style="color: red;">*</span>)</div>
                            <div class="info-context">
                                <input type="text" style="width: 250px" class="m-input" placeholder="Nhập số điện thoại">       
                            </div>
                        </div>
                    </div>
                    <div class="r-input">B. Thông tin công việc</div>
                    <div class="body-line"></div>
                    <div class="r-input">
                        <div class="r-info">
                            <div class="info-label">Vị trí</div>
                            <div class="info-context">
                                <select style="width: 250px; font-size: 13px;" name="" id="">
                                    <option value="">Giám đốc</option>
                                    <option value="">Quản lý</option>
                                    <option value="">Nhân viên</option>
                                </select>                    
                            </div>
                        </div>
                        <div class="r-info">
                            <div class="info-label">Phòng ban</div>
                            <div class="info-context">
                                <select style="width: 250px; font-size: 13px;" name="" id="">
                                    <option value="">Phòng kế toán</option>
                                    <option value="">Phòng nhân sự</option>
                                    <option value="">Phòng code</option>
                                </select>                    
                            </div>
                        </div>
                    </div>
                    <div class="r-input">
                        <div class="r-info">
                            <div class="info-label">Mã số thuế cá nhân</div>
                            <div class="info-context">
                                <input type="text" style="width: 250px" class="m-input" placeholder="Nhập mã số thuế cá nhân">       
                            </div>
                        </div>
                        <div class="r-info">
                            <div class="info-label">Mức lương cơ bản</div>
                            <div class="info-context">
                                <input type="text" style="width: 250px" class="m-input" placeholder="Nhập lương cơ bản">       
                            </div>
                        </div>
                    </div>
                    <div class="r-input">
                        <div class="r-info">
                            <div class="info-label">Ngày gia nhập công ty</div>
                            <div class="info-context">
                                <input type="text" style="width: 250px" class="m-input m-input-icon-right m-icon-calender m-icon-16px   " placeholder="Nhập ngày gia nhập công ty">        
                            </div>
                        </div>
                        <div class="r-info">
                            <div class="info-label">Tình trạng công việc</div>
                            <div class="info-context">
                                <select style="width: 250px; font-size: 13px;" name="" id="">
                                    <option value="">Thử việc</option>
                                    <option value="">Thất nghiệp</option>
                                    <option value="">Đang làm việc tại công ty</option>
                                    <option value="">Nghỉ việc</option>
                                </select>                    
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="m-dialog-footer">
                <button class="m-btn f-btn f-btn-hover">Hủy</button>
                <button class="m-btn f-btn m-btn-icon m-icon-save m-icon-24px " style="margin-right: 24px;">Lưu</button>
            </div>
        </div>
</template>
<script >
    export default {

        methods: {
            closeOnClick() {
                document.getElementById("dialog").style.display = "none";
            }

        },

        data() {
            return {
                isShow: false,
            };
        },
    }
</script>

<style scoped>
    @import url("../../style/components/dialog.css");
</style>