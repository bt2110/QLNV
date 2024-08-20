import { createApp } from 'vue'
// import { createRouter, createWebHistory } from 'vue-router'
import App from './App.vue'
import router from './router/index.js'
import axios from 'axios'
import VueAxios from 'vue-axios'
// import EmployeeList from './view/employee/EmployeeList.vue'
// import ReportList from './view/report/ReportList.vue'

// const routes = [
//     { path: "/employee", component: EmployeeList },
//     { path: "/report", component: ReportList },
// ]

// const router = createRouter({
//     history: createWebHistory(process.env.BASE_URL), routes
// })

createApp(App).use(router,axios,VueAxios).mount('#app')
