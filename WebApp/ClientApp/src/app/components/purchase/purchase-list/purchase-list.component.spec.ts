/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { PurchaseListComponent } from './purchase-list.component';

let component: PurchaseListComponent;
let fixture: ComponentFixture<PurchaseListComponent>;

describe('PurchaseList component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ PurchaseListComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(PurchaseListComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});