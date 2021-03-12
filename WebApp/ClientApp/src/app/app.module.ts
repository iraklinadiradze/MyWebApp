import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ServiceWorkerModule } from '@angular/service-worker';

// vendor dependencies
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
// app
import { Config } from './common/index';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

// Kendo UI
import { GridModule } from '@progress/kendo-angular-grid';
import { ChartsModule } from '@progress/kendo-angular-charts';
import { DialogModule } from '@progress/kendo-angular-dialog';
import { InputsModule, FormFieldModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { LayoutModule } from '@progress/kendo-angular-layout';
import { TreeViewModule } from '@progress/kendo-angular-treeview';
import { IconsModule } from '@progress/kendo-angular-icons';
import { ToolBarModule } from '@progress/kendo-angular-toolbar';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';

// Components
import { LoadingComponent } from './shared/spinner.component';

import { DynamicComponentDirective } from './common/DynamicDirectives/dynamic-component.directive';
import { DynamicComponentService } from './common/DynamicDirectives/dynamic-component.service';
import { KendoGridColumnDateFormatDirective } from './common/KendoGridColumnDateFormatDirective';

import { ClientListComponent } from './components/client/client-list/client-list.component';
import { ClientFetchDataComponent } from './components/client/client-fetchdata/client-fetchdata.component';
import { ClientCruComponent } from './components/client/client-cru/client-cru.component';

// environment
import { environment } from '../environments/environment';
import { from } from 'rxjs';




Config.PLATFORM_TARGET = Config.PLATFORMS.WEB;

export function createTranslateLoader(http: HttpClient) {
    return new TranslateHttpLoader(http as any, './assets/i18n/', '.json');
}

@NgModule({
    declarations: [
        AppComponent,
        LoadingComponent,

        ClientListComponent,
        ClientFetchDataComponent,
        ClientCruComponent,

        DynamicComponentDirective,
        KendoGridColumnDateFormatDirective
    ],
    imports: [
        AppRoutingModule,
        ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production }),
        BrowserModule,
        ChartsModule,
        GridModule,
        DialogModule,
        InputsModule,
        ButtonsModule,
        LayoutModule,
        TreeViewModule,
        IconsModule,
        ToolBarModule,
        CommonModule , 
        FormsModule,
        ReactiveFormsModule,
        DateInputsModule,
        LabelModule,
        DropDownsModule,
        BrowserAnimationsModule,
        HttpClientModule,
        TranslateModule.forRoot({
            loader: {
                provide: TranslateLoader,
                useFactory: (createTranslateLoader),
                deps: [HttpClientModule]
            }
        })
    ],
    providers: [DynamicComponentService, KendoGridColumnDateFormatDirective],
    bootstrap: [AppComponent]
})
export class AppModule {}
