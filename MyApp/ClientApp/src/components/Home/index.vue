<template>
    <div>
        <ReportForm />
    </div>
</template>

<script lang="ts">
import ReportForm from './ReportForm.vue';
import { Vue, Component, Prop } from 'vue-property-decorator';

@Component({
  components: {
        ReportForm,
  },
})
export class Home extends Vue {
  @Prop({ default: '' }) name: string;

}
export default Home;
</script>
