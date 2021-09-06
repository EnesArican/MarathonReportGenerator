import Vue from 'vue';
import Router, { Route } from 'vue-router';
import Home from '../components/Home/index.vue';
import ReportForm from '../components/Home/ReportForm.vue';

export enum Routes {
  Home = '/',
  ReportForm = '/report-form',
}

Vue.use(Router);



const routes = [
  { path: '*', redirect: '/' },
  { path: Routes.ReportForm, component: ReportForm },
  { path: Routes.Home, component: Home, props: { name: 'Vue' } },
];

export const router = new Router ({
    mode: 'history',
    linkActiveClass: 'active',
    routes,
});

export const redirect = (path: string) => {
  const externalUrl = path.indexOf('://') >= 0;
  if (!externalUrl) {
      router.push({ path });
  } else {
      location.href = path;
  }
};

