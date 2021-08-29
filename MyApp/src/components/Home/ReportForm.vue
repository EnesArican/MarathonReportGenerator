<template>
    <v-row  justify="center">
        <v-col cols="7" sm="9">
            <h3>Report Generator</h3>

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
import { store, bus, client, checkAuth, toPascalCase, splitOnFirst } from '../../shared';
import { Register } from '../../shared/dtos';
import { Routes, redirect } from '../../shared/router';

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

    async submit() {
        try {
            this.loading = true;
            this.responseStatus = null;

            const response = await client.post(new Register({
                displayName: this.displayName,
                email: this.email,
                password: this.password,
                confirmPassword: this.confirmPassword,
                autoLogin: this.autoLogin,
            }));

            await checkAuth();

            redirect(Routes.Home);

        } catch (e) {
            this.responseStatus = e.responseStatus || e;
        } finally {
            this.loading = false;
        }
    }

    newUser(email: string) {
        const names = email.split('@');
        this.displayName = toPascalCase(names[0]) + ' ' + toPascalCase(splitOnFirst(names[1], '.')[0]);
        this.email = email;
        this.password = this.confirmPassword = 'p@55wOrd';
    }

    reportTypeChange(a: string)
    {
        // tslint:disable-next-line:no-console
        console.log(a);
    }

}
export default ReportForm;
</script>
