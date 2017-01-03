﻿namespace NEventStore.Domain.Tests
{
    using System;
    using NEventStore.Persistence.AcceptanceTests.BDD;
    using Xunit;
    using XunitShould;

    public class when_an_aggregate_is_created : SpecificationBase
    {
        private Guid _aggregateId;
        private TestAggregate _testAggregate;

        protected override void Because()
        {
            _aggregateId = Guid.NewGuid();
            _testAggregate = new TestAggregate(_aggregateId, "Test");
        }

        [Fact]
        public void should_have_raised_creation_event()
        {
            _testAggregate.HasRaisedEvent<TestAggregateCreatedEvent>().ShouldEqual(true);
        }

        [Fact]
        public void creation_event_should_carry_the_correct_data()
        {
            var evt = _testAggregate.LastRaisedEvent<TestAggregateCreatedEvent>();
            evt.Id.ShouldEqual(_aggregateId);
            evt.Name.ShouldEqual("Test");
        }

        [Fact]
        public void should_have_name()
        {
            _testAggregate.Name.ShouldEqual("Test");
        }

        [Fact]
        public void aggregate_version_should_be_one()
        {
            _testAggregate.Version.ShouldEqual(1);
        }
    }

    public class when_updating_an_aggregate : SpecificationBase
    {
        private Guid _aggregateId;
        private TestAggregate _testAggregate;

        protected override void Context()
        {
            _aggregateId = Guid.NewGuid();
            _testAggregate = new TestAggregate(_aggregateId, "Test");
        }

        protected override void Because()
        {
            _testAggregate.ChangeName("UpdatedTest");
        }

        [Fact]
        public void should_have_raised_an_update_event()
        {
            _testAggregate.HasRaisedEvent<NameChangedEvent>().ShouldEqual(true);
        }

        [Fact]
        public void creation_event_should_carry_the_correct_data()
        {
            var evt = _testAggregate.LastRaisedEvent<NameChangedEvent>();
            evt.Id.ShouldEqual(_aggregateId);
            evt.Name.ShouldEqual("UpdatedTest");
        }

        [Fact]
        public void name_change_should_be_applied()
        {
            _testAggregate.Name.ShouldEqual("UpdatedTest");
        }

        [Fact]
        public void applying_events_automatically_increments_version()
        {
            _testAggregate.Version.ShouldEqual(2);
        }
    }
}