/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ClientCruComponent } from './client-cru.component';

let component: ClientCruComponent;
let fixture: ComponentFixture<ClientCruComponent>;

describe('ClientCRU component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ClientCruComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ClientCruComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});
