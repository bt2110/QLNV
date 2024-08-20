import { createRouter, createWebHistory } from 'vue-router'
import EmployeeList from '../view/employee/EmployeeList.vue'
import EmployeeDetail from '../view/employee/EmployeeDetail.vue'
import ReportList from '../view/report/ReportList.vue'
import overview from '../view/overview/OverviewView.vue'
import shopping from '../view/shopping/ShoppingView.vue'
import config from '../view/configuration/ConfigurationView.vue'


const routes = [
    { path: '/employee', component: EmployeeList },
    { path: '/employeedetail', component: EmployeeDetail },
    { path: '/report', component: ReportList },
    { path: '/overview', component: overview },
    { path: '/shopping', component: shopping },
    { path: '/config', component: config },
]

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL), routes
})

export default router