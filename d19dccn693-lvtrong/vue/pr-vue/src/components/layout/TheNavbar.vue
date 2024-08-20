<template>
    <div class="navbar"> 
                <router-link class="menu-item" to="/overview">
                    <div class="menu-icon m-icon m-icon-dashboard "></div>
                    <div class="menu-text">Tổng Quan</div>
                 </router-link>

                <router-link class="menu-item" to="/report">
                    <div class="menu-icon m-icon m-icon-report"></div>
                    <div class="menu-text">Báo cáo</div>
                </router-link>

                <router-link class="menu-item" to="/shopping">
                    <div class="menu-icon m-icon m-icon-document"></div>
                    <div class="menu-text">Mua hàng</div>
                </router-link>

                <router-link class="menu-item" to="/employee">
                    <div class="menu-icon m-icon m-icon-employee"></div>
                    <div class="menu-text">Danh mục nhân viên</div>
                </router-link>

                <router-link class="menu-item" to="/config">
                    <div class="menu-icon m-icon m-icon-setting"></div>
                    <div class="menu-text">Thiết lập hệ thống</div>
                </router-link>
            </div>
</template>
<script>
    export default {

    }
</script>

<style scoped>
   .navbar {
    width: 226px;
    height: 100%;
    flex-shrink: 0;
    box-sizing: border-box;
    border-right: 1px solid #bbbbbb;

    }

    .menu-item {
        display: flex;
        height: 44px;
        width: 100%;
        box-sizing: border-box;
        align-items: center;
        cursor: pointer;
        text-decoration: none;
        color: black;

    }

    .menu-item:hover {
        background-color: #e5e5e5;
    }

    .menu-item .menu-icon {
        margin-left: 16px;
        margin-right: 10px;
        width: 20px;
        height: 20px;
        flex-shrink: 0;
    }
    .router-link-active{
        background-color: #109160;
        color: white !important;
    } 
</style>
