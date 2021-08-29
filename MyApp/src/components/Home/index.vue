<template>
    <div>
        <ReportForm />
    </div>
</template>

<script lang="ts">
import ReportForm from './ReportForm.vue';
import { store, signout } from '../../shared';
import { Vue, Component, Prop } from 'vue-property-decorator';

@Component({
  components: {
        ReportForm,
  },
})
export class Home extends Vue {
  @Prop({ default: '' }) name: string;
  signout = signout;

  get userSession() {
    return store.userSession;
  }

}
export default Home;
</script>
