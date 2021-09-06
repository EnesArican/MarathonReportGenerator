<template>
    <div class="form-group">
        <v-input placeholder="Your name" v-model="txtName" />
        <h3 class="result pt-2">{{ result }}</h3>
    </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { Component, Prop, Watch } from 'vue-property-decorator';

@Component
export class HelloApi extends Vue {
    @Prop() public name: string;
    public txtName: string = '';
    public result: string = '';

    public mounted() {
        this.nameChanged(this.name);
    }

    @Watch('txtName')
    public onNameChanged(value: string, oldValue: string) {
        this.nameChanged(value);
    }

    public async nameChanged(name: string) {
        console.log(name);
        this.txtName = name;
    }
}
export default HelloApi;
</script>

<style lang="scss">
@import '../../app.scss';

.result {
    color: darken($navbar-background, 10%);
}
</style>