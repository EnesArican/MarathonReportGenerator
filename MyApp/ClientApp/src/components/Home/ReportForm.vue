<template>
    <v-row  justify="center">
        <v-col cols="7" sm="9">
            <h3>Report Generator</h3>
            <div v-if="loading" class="loading">
                Loading...
            </div>

            <v-form @submit.prevent="submit">
                <v-container>
                    <v-row>
                        <v-col cols="6">
                            <v-select :items="items" label="Report Type" v-on:change="reportTypeChange" solo></v-select>
                        </v-col>
                    </v-row>
                    <v-row>
                        <v-col cols="6">
                            <v-select :items="items" label="Report Type"></v-select>
                        </v-col>
                    </v-row>
                </v-container>
            </v-form>
        </v-col>
    </v-row>
</template>

<script lang="ts">
import { Vue, Component, Watch, Prop } from 'vue-property-decorator';
import { toPascalCase, splitOnFirst } from '../../shared';

@Component
export class ReportForm extends Vue {

    displayName = '';
    email = 'Hello';
    userName = '';
    password = '';
    confirmPassword = '';
    autoLogin = true;
    loading = false;
    responseStatus = null;
    items = ['Class Register', 'Behaviour', 'Other'];

    async created()
    {
        console.log('inside created method');
        this.loading = true;
        await this.fetchData();
    }


    async fetchData() {
        try {
            this.loading = true;

            console.log('inside fetch method');

            await fetch('/WeatherForecast')
                .then((r) => r.json())
                .then((j) => {
                    console.log(j);
                });
        } catch (e) {
            this.responseStatus = e.responseStatus || e;
        } finally {
            this.loading = false;
        }
    }


    reportTypeChange(a: string)
    {
        // tslint:disable-next-line:no-console
        console.log(a);
    }

}
export default ReportForm;
</script>
